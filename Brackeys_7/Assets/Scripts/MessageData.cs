using MyBox;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/MessageData", order = 1)]
public class MessageData : ScriptableObject
{

    public enum who { YOU, OTHER }

    [System.Serializable]
    public struct Data
    {
        public who talking;
        public Sprite attachment;
        [TextArea]
        public string value;
    }

    public Sprite photoYou;
    public Sprite photoOther;

    public Data[] messages;

    public int nextIndexTab = 0;
    public int level = 1;

    [ButtonMethod]
    public void AddLinkInLastMessage()
    {
        messages[messages.Length - 1].value += "<align=\"center\"><size=150%><color=\"yellow\"><link=\"ID\"> CLICK HERE! </link>";
    }
}
