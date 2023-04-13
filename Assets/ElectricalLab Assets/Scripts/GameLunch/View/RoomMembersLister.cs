using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class RoomMembersLister : MonoBehaviourPunCallbacks
{
	public GameObject MembersPanel;
	public GameObject MemberListItemPrefab;

	private List<GameObject> memberListItems = new List<GameObject>();

	public override void OnEnable()
	{
		base.OnEnable();
		UpdateMembersListObjects();
	}
	public override void OnPlayerEnteredRoom(Player newPlayer)
	{
		UpdateMembersListObjects();
	}

	public override void OnPlayerLeftRoom(Player otherPlayer)
	{
		UpdateMembersListObjects();
	}
	public void UpdateMembersListObjects()
	{
		ClearMemberList();
		foreach (Player player in PhotonNetwork.CurrentRoom.Players.Values)
		{
			CreateMemberListObject(player);
		}
	}
	public void CreateMemberListObject(Player player)
	{
		var memberListItem = Instantiate(MemberListItemPrefab, MembersPanel.transform);
		var memberListInfo = memberListItem.GetComponent<MemberListInfo>();
		if (memberListInfo != null)
		{
			memberListInfo.SetPlayerInfo(player);
		}
		memberListItems.Add(memberListItem);
	}

	public void ClearMemberList()
	{
		foreach (GameObject memberListItem in memberListItems)
		{
			Destroy(memberListItem);
		}
		memberListItems.Clear();
	}
}