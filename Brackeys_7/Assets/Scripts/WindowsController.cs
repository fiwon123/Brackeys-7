using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowsController : MonoBehaviour
{
    
    [Header("Images")]
    [SerializeField]
    public Sprite[] closeImages;
    public bool needRandom;
    public Button closeButton;
    public GameObject windowsAdd;

    public Image background;

    public void Start(){
        //windowsAdd = gameObject.GetComponent<Transform>().parent.gameObject;
        RandomizeImage();

        if(needRandom){
            RandomizePlace();
        }
    }


    private void RandomizeImage(){
        int i=0, total = closeImages.Length;
        i = (int)Random.Range(i, total);
        closeButton.GetComponent<Image>().sprite = closeImages[i];
    }

    
    public void RandomizePlace(){
        RectTransform rt = (RectTransform)windowsAdd.transform;
        float width = rt.rect.width;
        float height = rt.rect.height;

        Debug.Log("essa é a altura: " + height + "\nEssa é a largura: " + width);
        
        closeButton.GetComponent<Transform>().localPosition = new Vector2 (Random.Range(10, (rt.rect.width-10)), Random.Range(10, (rt.rect.height-10)));
        Debug.Log("tamanho atual é :" + closeButton.GetComponent<Transform>().position);

        //windowsAdd.GetComponentInChildren<Button>.anchoredPosition;
    }   

    public void ClickRight(){
        //Debug.Log("Sprite Clicked");
        Destroy(windowsAdd);
    }
}