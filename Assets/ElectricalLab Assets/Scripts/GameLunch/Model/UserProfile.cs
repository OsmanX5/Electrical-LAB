using System.Collections;
using System.Collections.Generic;
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
	private DeviceType deviceType;
	private PlayMode playMode;
	private UserRole userRole;


	public DeviceType DeviceType { get => deviceType; set => deviceType = value; }
	public PlayMode PlayMode { get => playMode; set => playMode = value; }
	public UserRole UserRole { get => userRole; set => userRole = value; }


}
