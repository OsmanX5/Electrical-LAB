using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MemberListInfo : MonoBehaviour
{
	public TMP_Text PlayerName;
	public GameObject TeacherBadge;
	public GameObject StudentBadge;
	public Player MemberPlayer;

	public void SetPlayerInfo(Player player)
	{
		this.MemberPlayer = player;
		PlayerName.text = player.NickName;
		UserRole role = UserRole.Student;
		if (player.CustomProperties.ContainsKey("UserRole"))
		{
			object roleObj = player.CustomProperties["UserRole"];
			if (roleObj != null && Enum.IsDefined(typeof(UserRole), roleObj))
			{
				role = (UserRole)roleObj;
				Debug.Log("Custom role: " + role);
			}
		}
		else
		{
			Debug.Log("No Key and all keys are");
		}
		Debug.Log("Custome role : "+ role);
		if(role == UserRole.Teacher)
		{
			TeacherBadge.SetActive(true);
			StudentBadge.SetActive(false);
			
		}
		if (role == UserRole.Student)
		{
			TeacherBadge.SetActive(false);
			StudentBadge.SetActive(true);
		}
	}

}
