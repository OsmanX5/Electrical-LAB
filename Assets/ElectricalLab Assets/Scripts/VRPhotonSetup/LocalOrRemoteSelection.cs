using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class LocalOrRemoteSelection : MonoBehaviourPunCallbacks
{
    public List<GameObject> LocalControllObjects;
	public List<MonoBehaviour> LocalControllScripts;
    void Start()
    {
		if (photonView.IsMine)
			SetupAsLoaclControll();
		else
			SetupAsRemoteControll();
    }
	void SetupAsLoaclControll()
	{
		
		foreach (var obj in LocalControllObjects)
			obj.SetActive(true);
		foreach (var comp in LocalControllScripts)
			comp.enabled = true;
	}
	void SetupAsRemoteControll()
	{
		foreach (var obj in LocalControllObjects)
			obj.SetActive(false);
		foreach (var comp in LocalControllScripts)
			comp.enabled = false;
	}


}
