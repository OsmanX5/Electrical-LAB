using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PanelsShowManger : MonoBehaviour
{
    [SerializeField] Transform PanelsParent;
	[SerializeField] List<GameObject> panels ;
    void Start()
    {
        GetPanelsFromHolder();

	}
    public void GetPanelsFromHolder()
    {
		panels = new List<GameObject>();
		if (PanelsParent == null)
			Debug.LogError("PanelsParent is null");
		foreach (Transform child in PanelsParent)
			panels.Add(child.gameObject);
	}
    public void ShowPanelWithName(string panelName)
    {
        foreach(GameObject panel in panels)
        {
            if (panel.name == panelName)
            {
                ShowPanel(panel);
                break;
            }
        }
    }
    public void ShowPanel(GameObject panel)
    {
        foreach (GameObject p in panels)
            p.SetActive(false);
        panel.SetActive(true);
    }
}
