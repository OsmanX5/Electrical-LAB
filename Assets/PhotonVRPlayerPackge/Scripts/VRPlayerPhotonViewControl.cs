using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Photon.Pun;
using UnityEngine.XR.Interaction.Toolkit;

public class VRPlayerPhotonViewControl : MonoBehaviourPunCallbacks
{
	public GameObject[] ObjectsToDisable;
	public ActionBasedController[] ComponentsToDisable;
	void Start()
	{
		

		if (!photonView.IsMine)
		{
			foreach (var obj in ObjectsToDisable)
			{
				obj.SetActive(false);
			}
			foreach (var comp in ComponentsToDisable)
			{
				comp.enabled = false;
			}
		}

	}
}
