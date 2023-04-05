using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserSettingsController : MonoBehaviour
{
    public UserSettings userSettings;
    void Start()
    {
		userSettings = gameObject.AddComponent<UserSettings>();
    }

    public void SetDeviceTypeMobile()
    {
        userSettings.DeviceType = DeviceType.Mobile;
    }
    public void SetDeviceTypeVR()
    {
        userSettings.DeviceType = DeviceType.VR;
    }
    public void SetDeviceTypeDesktop()
    {
		userSettings.DeviceType = DeviceType.Desktop;
	}
    public void SetRoleAsTeacher()
    {
        userSettings.UserRole = UserRole.Teacher;
    }
    public void SetRoleAsStudent()
    {
        userSettings.UserRole = UserRole.Student;
    }
    public void SetPlayModeAsLocal()
    {
        userSettings.PlayMode = PlayMode.Local;
    }
    public void SetPlayModeAsOnline()
    {
        userSettings.PlayMode = PlayMode.Online;
    }
}
