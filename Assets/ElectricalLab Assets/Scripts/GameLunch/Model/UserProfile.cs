using System.Collections.Generic;
using ExitGames.Client.Photon;
using Photon;
using UnityEngine;

public enum DeviceType
{
    Desktop,
	Mobile,
	VR
}
public enum UserRole
{
	Teacher,
	Student
}
public enum PlayMode
{
	Local,
	Online
}
public class UserProfile : MonoBehaviour
{

	private DeviceType _deviceType ;
	private PlayMode _playMode;
	private UserRole _userRole;

	public DeviceType DeviceType { get => _deviceType; set => _deviceType = value; }
	public PlayMode PlayMode { get => _playMode; set => _playMode = value; }
	public UserRole UserRole { get => _userRole; set => _userRole = value; }

	public Hashtable GetProfile()
	{
		Hashtable profile = new Hashtable();
		profile["DeviceType"] = DeviceType;
		profile["UserRole"] = UserRole;
		return profile;
	}
}
