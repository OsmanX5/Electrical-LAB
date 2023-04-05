using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PhotonConnection : MonoBehaviourPunCallbacks
{
	PanelsShowManger PanelsManger;
	void Start()
	{
		PanelsManger = GetComponent<PanelsShowManger>();
	}
	public void ConnectToPhoton()
	{
		if (PhotonNetwork.IsConnected)
		{
			PanelsManger.ShowConnectWithName();
			return;
		}
		PhotonNetwork.ConnectUsingSettings();
		PanelsManger.ShowConnecting();
	}

	public override void OnConnectedToMaster()
	{
		Debug.Log("Connected to Photon master server.");
		PanelsManger.ShowConnectWithName();
	}

	public override void OnDisconnected(DisconnectCause cause)
	{
		Debug.LogWarningFormat("Disconnected from Photon with reason {0}.", cause);
		PanelsManger.ShowError();
	}

}