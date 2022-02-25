using MyBox;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabsManager : MonoBehaviour
{
    [SerializeField]
    private Transform allTabs;
    [SerializeField]
    private Transform allPanels;

    [SerializeField]
    private List<Transform> panels;
    [SerializeField]
    private List<DataTab> tabs;

    [System.Serializable]
    public struct DataTab 
    {
        public Transform tab;
        public int indexPanel;

        public DataTab(Transform tab, int indexPanel)
        {
            this.tab = tab;
            this.indexPanel = indexPanel;
        }
    }
    private void Start()
    {
        int index = 0;
        foreach (DataTab data in tabs)
        {
            data.tab.GetComponent<Button>().onClick.AddListener(delegate { SelectTab(data.indexPanel); } );
            index++;
        }
    }

#if UNITY_EDITOR
    [ButtonMethod]
    public void Setup()
    {
        if (!allTabs || !allPanels)
        {
            Debug.LogError("allTabs/allPanels is null");
        }

        panels.Clear();

        foreach (Transform panel in allPanels)
        {
            panels.Add(panel);
        }

        tabs.Clear();

        int index = 0;
        foreach (Transform tab in allTabs)
        {
            tabs.Add(new DataTab(tab, index));
            index++; 
        }


    }
#endif

    public void SelectTab(int index)
    {
        foreach (Transform panel in allPanels)
        {
            panel.gameObject.SetActive(false);
        }

        panels[index].gameObject.SetActive(true);
    }

}
