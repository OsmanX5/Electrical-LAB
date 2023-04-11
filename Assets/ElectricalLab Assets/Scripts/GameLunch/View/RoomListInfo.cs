using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoomListInfo : MonoBehaviour
{
	public TMP_Text RoomNameText;
	public Button joinRoomButton;
	private void Awake()
	{
		joinRoomButton.onClick.AddListener(JoinTheRoom);
	}
	public string RoomName { get;  set; }
	public void SetRoomInfo(RoomInfo roomInfo)
	{
		RoomName = roomInfo.Name;
		RoomNameText.text = roomInfo.Name;
	}
	void JoinTheRoom()
	{
		PhotonNetwork.JoinRoom(RoomName);
	}
}
