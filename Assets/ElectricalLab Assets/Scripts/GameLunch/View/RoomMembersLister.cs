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

	public override void OnPlayerEnteredRoom(Player newPlayer)
	{
		CreateMemberListObject(newPlayer);
	}

	public override void OnPlayerLeftRoom(Player otherPlayer)
	{
		DeletMemberListObject(otherPlayer);
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

	public void DeletMemberListObject(Player player)
	{
		foreach (GameObject memberListItem in memberListItems)
		{
			var memberListInfo = memberListItem.GetComponent<MemberListInfo>();
			if (memberListInfo != null && memberListInfo.MemberPlayer == player)
			{
				Destroy(memberListItem);
				memberListItems.Remove(memberListItem);
				break;
			}
		}
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