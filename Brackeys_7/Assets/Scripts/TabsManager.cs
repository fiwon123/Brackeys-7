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

    public enum state { CHAT = 0, PUZZLE = 1, INFO = 2, CREDITS = 3}

    [System.Serializable]
    public struct DataTab 
    {
        public Transform tab;
        public Button button;
        public int indexPanel;

        public DataTab(Transform tab, Button button,int indexPanel)
        {
            this.tab = tab;
            this.button = button;
            this.indexPanel = indexPanel;
        }
    }

    public static TabsManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        int index = 0;
        foreach (DataTab data in tabs)
        {
            data.button.onClick.AddListener(delegate { SelectTab(data.indexPanel); } );
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
            tabs.Add(new DataTab(tab, tab.GetComponent<Button>(), index));
            index++; 
        }

        UnityEditor.EditorUtility.SetDirty(this);
    }
#endif

    public void SelectTab(int index)
    {
        if (GameManager.Instance.isPuzzleStarted || !GameManager.Instance.gameStarted || GameManager.Instance.endGame)
        {
            return;
        }

        foreach (Transform panel in allPanels)
        {
            panel.gameObject.SetActive(false);
        }

        tabs[index].button.Select();
        panels[index].gameObject.SetActive(true);
    }

}
