using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserProfileController : MonoBehaviour
{
    public void SetDeviceTypeMobile()
    {
        UserProfile.DeviceType = DeviceType.Mobile;
    }
    public void SetDeviceTypeVR()
    {
        UserProfile.DeviceType = DeviceType.VR;
    }
    public void SetDeviceTypeDesktop()
    {
		UserProfile.DeviceType = DeviceType.Desktop;
	}
    public void SetRoleAsTeacher()
    {
        UserProfile.UserRole = UserRole.Teacher;
    }
    public void SetRoleAsStudent()
    {
        UserProfile.UserRole = UserRole.Student;
    }
    public void SetPlayModeAsLocal()
    {
        UserProfile.PlayMode = PlayMode.Local;
    }
    public void SetPlayModeAsOnline()
    {
        UserProfile.PlayMode = PlayMode.Online;
    }
	
}
