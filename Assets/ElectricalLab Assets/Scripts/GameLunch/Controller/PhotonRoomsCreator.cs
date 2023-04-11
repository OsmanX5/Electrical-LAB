using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonRoomsCreator : MonoBehaviour
{
	// attach to the RoomName InputField
	string getRoomNameFromInputField()
	{
		var RoomNameInputField = GetComponent<TMPro.TMP_InputField>();
		if (RoomNameInputField == null)
		{
			Debug.LogError("RoomName Inputfield is null");
			return "";
		}
		return RoomNameInputField.text;
	}
	public void CreateRoom()
	{

		string RoomName = getRoomNameFromInputField();
		if(string.IsNullOrEmpty(RoomName) )
			RoomName = PhotonNetwork.NickName + " Room";
		RoomOptions roomOptions = new RoomOptions();
		roomOptions.IsOpen= true;
		roomOptions.IsVisible = true;
		roomOptions.MaxPlayers = 4;
		PhotonNetwork.CreateRoom(RoomName);
	}
}
