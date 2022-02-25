using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowsController : MonoBehaviour
{
    
    [Header("Images")]
    [SerializeField]
    public Sprite[] closeImages;
    public int stage;
    public Button closeButton;
    public GameObject windowsAdd;

    public void Start(){
        //windowsAdd = gameObject.GetComponent<Transform>().parent.gameObject;
        randomizeImage();

        if(stage > 1){
            randomizePlace();
        }
    }


    private void randomizeImage(){
        int i=0, total = closeImages.Length;
        i = (int)Random.Range(i, total);
        closeButton.GetComponent<Image>().sprite = closeImages[i];
    }

    
    private void randomizePlace(){
        RectTransform rt = (RectTransform)windowsAdd.transform;
        float width = rt.rect.width;
        float height = rt.rect.height;
        
        this.GetComponent<Transform>().position = new Vector2 (Random.Range(0, width), Random.Range(0, height));

        //windowsAdd.GetComponentInChildren<Button>.anchoredPosition;
    }

    public void OnMouseDown(){
        //Debug.Log("Sprite Clicked");
        Destroy(windowsAdd);
    }
}
