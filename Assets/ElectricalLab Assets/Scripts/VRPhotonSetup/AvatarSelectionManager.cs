using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
public class AvatarSelectionManager : MonoBehaviourPunCallbacks
{
	[SerializeField] GameObject[] TeacherObjects;
	[SerializeField] GameObject[] StudentObjects;
	void Start()
	{
		if (photonView.IsMine)
		{
			photonView.RPC("SetupAvatar",RpcTarget.AllBuffered,UserProfile.UserRole);
		}
		
	}

	[PunRPC]
	public void SetupAvatar(UserRole role)
	{
		if (role == UserRole.Teacher)
			SetupAsTeacher();
		if (role == UserRole.Student)
			SetupAsStudent();
	}
	void SetupAsStudent()
	{
		foreach (GameObject obj in TeacherObjects)
		{
			obj.SetActive(false);
		}
		foreach (GameObject obj in StudentObjects)
		{
			obj.SetActive(true);
		}

	}
	void SetupAsTeacher()
	{
		foreach (GameObject obj in TeacherObjects)
		{
			obj.SetActive(true);
		}
		foreach (GameObject obj in StudentObjects)
		{
			obj.SetActive(false);
		}

	}
}
