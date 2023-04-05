using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PhotonConnection : MonoBehaviourPunCallbacks
{
	PanelsShowManger PanelsManger;
	UserProfile userProfile;
	void Start()
	{
		PanelsManger = GetComponent<PanelsShowManger>();
	}
	public void ConnectToPhotonWithNickName()
	{
		ConnectToPhoton();
	}
	void ConnectToPhoton()
	{
		if (PhotonNetwork.IsConnected)
		{
			PanelsManger.ShowConnectWithName();
			return;
		}
		PhotonNetwork.ConnectUsingSettings();
		PanelsManger.ShowConnecting();
	}

	public void CreateRoom()
	{
		string RoomName =  PhotonNetwork.NickName + "Room";
		PhotonNetwork.CreateRoom(RoomName);
	}

	public override void OnConnectedToMaster()
	{
		Debug.Log("Connected to Photon master server. Mr." + PhotonNetwork.NickName);
		if (userProfile.UserRole == UserRole.Teacher)
			PanelsManger.ShowInsideRoom();
		else
			PanelsManger.ShowListRoom();
	}

	public override void OnDisconnected(DisconnectCause cause)
	{
		Debug.LogWarningFormat("Disconnected from Photon with reason {0}.", cause);
		PanelsManger.ShowError();
	}

}