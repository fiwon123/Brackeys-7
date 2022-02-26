using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSuccess : MonoBehaviour
{

    public void WinPuzzle()
    {
        InfoManager.Instance.EnableInfo(GameManager.Instance.currentLevel-1);
        GameManager.Instance.WinPuzzle();
        TabsManager.Instance.SelectTab((int)TabsManager.state.INFO);
    }
}
