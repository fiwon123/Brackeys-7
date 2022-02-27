using MyBox;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour
{
    [Foldout("Data", true)]
    [SerializeField]
    private MessageData data;
    private int indexMessage;
    [SerializeField]
    private float intervalMessage = 1.5f;

    [Foldout("Setup", true)]
    [SerializeField]
    private Scrollbar scrollBar;
    [SerializeField]
    private GameObject viewerPort;

    [SerializeField]
    private GameObject panelMessagePrefab;
    [SerializeField]
    private Transform content;

    public Coroutine coroutineStartChat;

    public static ChatManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        if (coroutineStartChat == null)
        {
            coroutineStartChat = StartCoroutine(StartChatCoroutine());
        }
    }

    private IEnumerator StartChatCoroutine()
    {
        while (!GameManager.Instance)
        {
            yield return null;
        }

        while (!GameManager.Instance.gameStarted)
        {
            yield return null;
        }

        while (indexMessage <= data.messages.Length) {
            yield return new WaitForSeconds(intervalMessage);
            NextMessage();
        }
    }

    private void Start()
    {
        Instance = this;
    }

    public int GetNextIndexTab()
    {
        return data.nextIndexTab;
    }

    private void Update()
    {
        scrollBar.value = 0;
    }

    public void EnableViewerPort()
    {
        viewerPort.SetActive(true);
    }

    public void DisableViewerPort()
    {
        viewerPort.SetActive(false);
    }

    public void SetData(MessageData data)
    {
        this.data = data;
        indexMessage = 0;
    }

    private void OnDisable()
    {
        coroutineStartChat = null;
    }

    [ButtonMethod]
    public void NextMessage()
    {
        if (indexMessage >= data.messages.Length)
        {
            coroutineStartChat = null;
            return;
        }

        GameObject panelMessage = Instantiate(panelMessagePrefab, content);
        MessagePanel messsagePanel = panelMessage.GetComponent<MessagePanel>();

        if (data.messages[indexMessage].attachment != null)
        {
            messsagePanel.SetAttachment(data.messages[indexMessage].attachment);
        }
        else
        {
            messsagePanel.SetAttachment(null);
        }

        if (data.messages[indexMessage].talking == MessageData.who.YOU)
        {
            messsagePanel.SetPhoto(data.photoYou);
            messsagePanel.ChangeLayoutToRight();
        }
        else
        {
            messsagePanel.SetPhoto(data.photoOther);
            messsagePanel.ChangeLayoutToLeft();
        }

        messsagePanel.SetText(data.messages[indexMessage].value);
        SoundManager.Instance.PlaySoundEffect(SoundEffect.Message);
        indexMessage++;
    }
}
