using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class LinkOpener : MonoBehaviour, IPointerClickHandler
{
    int nextIndexTab;
    bool isOpened;

    private void Start()
    {
        nextIndexTab = ChatManager.Instance.GetNextIndexTab();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        TMP_Text pTextMeshPro = GetComponent<TMP_Text>();
        int linkIndex = TMP_TextUtilities.FindIntersectingLink(pTextMeshPro, eventData.position, null);  // If you are not in a Canvas using Screen Overlay, put your camera instead of null
        if (linkIndex != -1 && !isOpened)
        { // was a link clicked?
            isOpened = true;
            TabsManager.Instance.SelectTab((int) TabsManager.state.PUZZLE);
        }
    }
}
