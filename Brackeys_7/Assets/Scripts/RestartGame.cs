using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartGame : MonoBehaviour
{
    public void OnMouseDown(){
        //Debug.Log("Sprite Clicked");
        GameManager.Instance.RestartPuzzle();
    }
}
