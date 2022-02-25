using MyBox;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessagePanel : MonoBehaviour
{
    [SerializeField]
    private HorizontalLayoutGroup layout;
    [SerializeField]
    private Image photo;
    [SerializeField]
    private Image attachment;
    [SerializeField]
    private TextMeshProUGUI textUI;


    [ButtonMethod]
    public void InvertOrder()
    {
        if (photo.transform.GetSiblingIndex() == 0)
        {
            photo.transform.SetAsLastSibling();
        }
        else
        {
            photo.transform.SetAsFirstSibling();
        }
    }

    [ButtonMethod]
    public void ChangeLayoutToRight()
    {
        layout.childAlignment = TextAnchor.UpperRight;
    }

    [ButtonMethod]
    public void ChangeLayoutToLeft()
    {
        layout.childAlignment = TextAnchor.UpperLeft;
    }

    public void SetText(string value)
    {
        textUI.text = value;
    }

    public void SetPhoto(Sprite value)
    {
        photo.sprite = value;
    }

    public void SetAttachment(Sprite value)
    {

        attachment.sprite = value;

        if (value)
        {
            attachment.gameObject.SetActive(true);
        }
        else
        {
            attachment.gameObject.SetActive(false);
        }

    }
}
