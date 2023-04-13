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

	public static DeviceType DeviceType ;
	public static PlayMode PlayMode;
	public static UserRole UserRole;


	public static Hashtable GetProfile()
	{
		Hashtable profile = new Hashtable();
		profile["DeviceType"] = DeviceType;
		profile["UserRole"] = UserRole;
		return profile;
	}
}
