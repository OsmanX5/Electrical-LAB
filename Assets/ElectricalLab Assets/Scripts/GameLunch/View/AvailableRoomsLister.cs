using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class AvailableRoomsLister : MonoBehaviourPunCallbacks
{
	public GameObject AvailableRoomsPanel;
	public GameObject RoomListItemPrefab;

	private List<GameObject> roomListItems = new List<GameObject>();

	public override void OnRoomListUpdate(List<RoomInfo> roomList)
	{
		UpdateRoomListObjects(roomList);
	}

	public void UpdateRoomListObjects(List<RoomInfo> newRoomsList)
	{
		DestoryOldListObjects();
		CreateNewRoomsListObjects(newRoomsList);
	}
	public void DestoryOldListObjects()
	{
		foreach (GameObject roomListItem in roomListItems)
			Destroy(roomListItem);
		roomListItems.Clear();
	}
	public void CreateNewRoomsListObjects(List<RoomInfo> roomList)
	{
		foreach (RoomInfo room in roomList)
		{
			CreateRoomListObject(room);
		}
	}
	public void CreateRoomListObject(RoomInfo room)
	{
		if (room.IsOpen && room.IsVisible && room.PlayerCount < room.MaxPlayers)
		{
			var roomListItem = Instantiate(RoomListItemPrefab, AvailableRoomsPanel.transform);
			var roomListInfo = roomListItem.GetComponent<RoomListInfo>();
			if (roomListInfo != null)
			{
				roomListInfo.SetRoomInfo(room);
			}
			roomListItems.Add(roomListItem);
		}
	}
}
