using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RoomNameTextUpdater : MonoBehaviourPunCallbacks
{
    TMPro.TMP_Text RoomNameText;
	public override void OnJoinedRoom()
	{
        Debug.Log(" to Room : " + PhotonNetwork.CurrentRoom.Name);
		UpdateRoomName();
	}
	void UpdateRoomName()
    {
		RoomNameText = GetComponent<TMPro.TMP_Text>();
		if (RoomNameText == null) {
			Debug.LogError("RoomNameText is null");
		}
		if (PhotonNetwork.InRoom)
            RoomNameText.text = "Welcome " + PhotonNetwork.NickName + " to : " + PhotonNetwork.CurrentRoom.Name;
        else
            RoomNameText.text = " You are not in a room";
    }
}
