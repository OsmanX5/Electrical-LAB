using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PhotonActions : MonoBehaviour
{
	PanelsShowManger PanelsManger;
	void Start()
	{
		PanelsManger = GetComponent<PanelsShowManger>();
		PanelsManger.ShowGamePlayMode();
		PhotonNetwork.AutomaticallySyncScene = true;
	}

	public void ConnectToPhotonWithNickName()
	{
		if (PhotonNetwork.IsConnected)
		{
			PanelsManger.ShowConnectWithName();
			return;
		}
		PhotonNetwork.ConnectUsingSettings();
		PanelsManger.ShowConnecting();
	}
	public void LeaveTheRoom()
	{
		if (PhotonNetwork.InRoom)
		{
			PhotonNetwork.LeaveRoom();
		}
	}
	public void LeaveTheLoopy()
	{
		if (PhotonNetwork.InLobby)
		{
			PhotonNetwork.LeaveLobby();
		}
	}
	public void Disconnect()
	{
		if (PhotonNetwork.IsConnected) 
		{
			PhotonNetwork.Disconnect();
		}
	}
	public void LoadGameScene()
	{
		PhotonNetwork.LoadLevel("GameScene");
	}


}
