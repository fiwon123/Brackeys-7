using MyBox;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour
{
    [SerializeField]
    private Scrollbar scrollBar;

    [SerializeField]
    private Message[] messages;
    private int indexMessage;

    [SerializeField]
    private GameObject panelMessagePrefab;
    [SerializeField]
    private Transform content;

    public Sprite photoYou;
    public Sprite photoOther;

    public enum who { YOU, OTHER }

    [System.Serializable]
    struct Message
    {
        public who talking;
        public Sprite attachment;
        public string value;
    }

    private void Start()
    {
        indexMessage = 0;
    }

    [ButtonMethod]
    public void AddLinkInLastMessage()
    {
        messages[messages.Length-1].value += "<color=\"blue\"><link=\"ID\"> my link </link>";
    }

    [ButtonMethod]
    public void NextMessage()
    {
        if (indexMessage >= messages.Length)
        {
            return;
        }

        GameObject panelMessage = Instantiate(panelMessagePrefab, content);
        MessagePanel messsagePanel = panelMessage.GetComponent<MessagePanel>();

        if (messages[indexMessage].attachment != null)
        {
            messsagePanel.SetAttachment(messages[indexMessage].attachment);
        }
        else
        {
            messsagePanel.SetAttachment(null);
        }

        if (messages[indexMessage].talking == who.YOU)
        {
            messsagePanel.SetPhoto(photoYou);
            messsagePanel.ChangeLayoutToRight();
        }
        else
        {
            messsagePanel.SetPhoto(photoOther);
            messsagePanel.ChangeLayoutToLeft();
        }

        scrollBar.value -= 1;

        messsagePanel.SetText(messages[indexMessage].value);
        indexMessage++;
    }
}
