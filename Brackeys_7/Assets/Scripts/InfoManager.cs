using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoManager : MonoBehaviour
{
    TextMeshProUGUI[] infos;

    public static InfoManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        DisableAllInfos();
    }

    private void DisableAllInfos()
    {
        for (int i = 0; i < infos.Length; i++)
        {
            infos[i].enabled = false;
        }
    }

    public void EnableInfo(int index)
    {
        infos[index].enabled = true;
    }
}
