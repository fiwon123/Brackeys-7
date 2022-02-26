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

    [Foldout("Setup", true)]
    [SerializeField]
    private Scrollbar scrollBar;
    [SerializeField]
    private GameObject viewerPort;

    [SerializeField]
    private GameObject panelMessagePrefab;
    [SerializeField]
    private Transform content;

    public static ChatManager Instance;

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

    [ButtonMethod]
    public void NextMessage()
    {
        if (indexMessage >= data.messages.Length)
        {
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
        indexMessage++;
    }
}
