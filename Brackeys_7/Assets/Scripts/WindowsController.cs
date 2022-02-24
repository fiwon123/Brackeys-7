using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowsController : MonoBehaviour
{
    //GameObject windowsAdd;
    [Header("Images")]
    [SerializeField]
    public Sprite[] closeImages;
    public Button closeButton;
    public int stage;

    public void Start(){
        //windowsAdd = this.gameObject;
        //randomizeImage(closeButton, closeImages);

        if(stage > 1){
            //randomizePlace();
        }
        Debug.Log("Iniciei direito");
    }
    public void rightClick(){
        Debug.Log("Entrei no 'rightClick'");
        Destroy(this);
    }

    private void randomizeImage(Button closeButton, Sprite[] closeImages){
        int i=0, total = closeImages.Length;
        i = (int)Random.Range(i, total);
        closeButton.GetComponent<Image>().sprite = closeImages[i];
    }

    /*
    private void randomizePlace(){
        RectTransform rt = (RectTransform)windowsAdd.transform;
        float width = rt.rect.width;
        float height = rt.rect.height;
        
        closeButton.GetComponent<RectTransform>().anchoredPosition = new Vector2 (Random.Range(0, width), Random.Range(0, height));

        //windows.GetComponentInChildren<Button>.anchoredPosition;

    }*/
}
