using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class PanelsShowManger : MonoBehaviour
{
    [SerializeField] Transform PanelsHolder;
	List<GameObject> panels ;
    PanelName CurrentPanel;
    void Start()
    {
        GetPanelsFromHolder();
	}
    public void GetPanelsFromHolder()
    {
		panels = new List<GameObject>();
		if (PanelsHolder == null)
			Debug.LogError("PanelsParent is null");
		foreach (Transform child in PanelsHolder)
			panels.Add(child.gameObject);
	}
    public void ShowPanel(PanelName panel)
    {
		CurrentPanel = panel;
		ShowCurrentPanel();
	}
    void ShowCurrentPanel()
    {
		foreach (GameObject p in panels)
		{
			p.SetActive(false);
			PanelInfo panelInfo = p.GetComponent<PanelInfo>();
			if (panelInfo == null)
				Debug.LogError($"Pleace notice that {p.name} hasn't a Panel Info Component");
			if (p.GetComponent<PanelInfo>().panelName == CurrentPanel)
				p.SetActive(true);
		}
	}

	public void ShowGamePlayMode() => ShowPanel(PanelName.GamePlayMode);

	public void ShowConnectWithName() => ShowPanel(PanelName.ConnectWithName);

	public void ShowConnecting() => ShowPanel(PanelName.Connecting);

	public void ShowError() => ShowPanel(PanelName.Error);

	public void ShowListRoom() => ShowPanel(PanelName.ListRoom);

	public void ShowInsideRoom() => ShowPanel(PanelName.InsideRoom);


}
