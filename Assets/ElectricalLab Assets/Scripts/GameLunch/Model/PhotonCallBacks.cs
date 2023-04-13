using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SocialPlatforms;
using Photon.Realtime;

public class PhotonCallBacks : MonoBehaviourPunCallbacks
{
	PanelsShowManger PanelsManger;
	void Start()
	{
		PanelsManger = GetComponent<PanelsShowManger>();
		PanelsManger.ShowGamePlayMode();
	}
	public override void OnConnectedToMaster()
	{
		Debug.Log("Connected to Photon master server. Mr." + PhotonNetwork.NickName);
		PhotonNetwork.SetPlayerCustomProperties(UserProfile.GetProfile());
		Debug.Log("properaties are set");
		foreach (var pair in PhotonNetwork.LocalPlayer.CustomProperties)
		{
			Debug.Log(pair.Key + " " + pair.Value);
		}
		PhotonNetwork.JoinLobby();
	}
	public override void OnJoinedLobby()
	{
		Debug.Log("Joined to Photon lobby");
		if (UserProfile.UserRole == UserRole.Teacher)
			PanelsManger.ShowCreateRoom();
		if (UserProfile.UserRole == UserRole.Student)
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
	public override void OnLeftRoom()
	{

		if(UserProfile.UserRole == UserRole.Teacher)
			PanelsManger.ShowCreateRoom();
		if (UserProfile.UserRole == UserRole.Student)
			PanelsManger.ShowListRoom();
	}
	public override void OnLeftLobby()
	{
		base.OnLeftLobby();
		PanelsManger.ShowConnectWithName();
	}
	
}
