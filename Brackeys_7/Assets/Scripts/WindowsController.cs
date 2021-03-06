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
            SetCloseButtonPosition();
        }
    }

    public void SpawnNewPopUp()
    {
        WindowSpawner.Instance.SpawnWindow();
    }

    private void RandomizeImage(){
        int i=0, total = closeImages.Length;
        i = (int)Random.Range(i, total);
        closeButton.GetComponent<Image>().sprite = closeImages[i];
    }

    
    public void SetCloseButtonPosition(){
        RectTransform rt = (RectTransform)windowsAdd.transform;
        var rect = rt.rect;
        closeButton.GetComponent<Transform>().localPosition =
            new Vector2 (Random.Range(10, (rect.width-10)), Random.Range(10, (rt.rect.height-10)));
    }

    public void SetClosePositionInRightCorner()
    {
        RectTransform rt = (RectTransform)windowsAdd.transform;
        var rect = rt.rect;
        closeButton.GetComponent<Transform>().localPosition = new Vector2(rect.width - 10, rect.height - 10);

    }

    public void OnClickSuccess(){
        Destroy(windowsAdd);
    }
}