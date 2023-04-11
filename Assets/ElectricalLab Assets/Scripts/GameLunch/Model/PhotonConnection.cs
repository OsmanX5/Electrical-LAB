using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PhotonConnection : MonoBehaviourPunCallbacks
{
	PanelsShowManger PanelsManger;
	UserProfile userProfile;
	void Start()
	{
		userProfile = GetComponent<UserProfile>();
		PanelsManger = GetComponent<PanelsShowManger>();
		PanelsManger.ShowGamePlayMode();
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


	public override void OnConnectedToMaster()
	{
		Debug.Log("Connected to Photon master server. Mr." + PhotonNetwork.NickName);
		PhotonNetwork.SetPlayerCustomProperties(userProfile.GetProfile());
		Debug.Log("properaties are set");
		foreach(var pair in PhotonNetwork.LocalPlayer.CustomProperties)
		{
			Debug.Log(pair.Key + " " + pair.Value);
		}
		PhotonNetwork.JoinLobby();
	}
	public override void OnJoinedLobby()
	{
		Debug.Log("Joined to Photon lobby");
		if (userProfile.UserRole == UserRole.Teacher)
			PanelsManger.ShowCreateRoom();
		if (userProfile.UserRole == UserRole.Student)
			PanelsManger.ShowListRoom();
	}
	public override void OnJoinedRoom()
	{
		Debug.Log("Joined to room");
		PanelsManger.ShowInsideRoom();
	}

	public override void OnDisconnected(DisconnectCause cause)
	{
		Debug.LogWarningFormat("Disconnected from Photon with reason {0}.", cause);
		PanelsManger.ShowError();
	}

}