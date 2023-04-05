using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public enum PanelName
{
	GamePlayMode,
    ConnectWithName,
    Connecting,
    Error,
    CreateRoom,
    ListRoom,
    InsideRoom
}
public class PanelInfo : MonoBehaviour
{
	public PanelName panelName;
}