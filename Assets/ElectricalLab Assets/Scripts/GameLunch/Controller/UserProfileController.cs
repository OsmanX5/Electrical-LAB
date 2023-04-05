using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserProfileController : MonoBehaviour
{
    public UserProfile userProfile;
    void Start()
    {
		userProfile = gameObject.AddComponent<UserProfile>();
    }

    public void SetDeviceTypeMobile()
    {
        userProfile.DeviceType = DeviceType.Mobile;
    }
    public void SetDeviceTypeVR()
    {
        userProfile.DeviceType = DeviceType.VR;
    }
    public void SetDeviceTypeDesktop()
    {
		userProfile.DeviceType = DeviceType.Desktop;
	}
    public void SetRoleAsTeacher()
    {
        userProfile.UserRole = UserRole.Teacher;
    }
    public void SetRoleAsStudent()
    {
        userProfile.UserRole = UserRole.Student;
    }
    public void SetPlayModeAsLocal()
    {
        userProfile.PlayMode = PlayMode.Local;
    }
    public void SetPlayModeAsOnline()
    {
        userProfile.PlayMode = PlayMode.Online;
    }
	public void SetUserName(string x)
	{
		PhotonNetwork.NickName = x;
	}
}
