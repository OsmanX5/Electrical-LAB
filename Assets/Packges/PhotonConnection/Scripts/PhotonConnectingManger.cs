using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class PhotonConnectingManger : MonoBehaviourPunCallbacks
{
    #region Public Functions
    public void EnterTheServer()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings();
    }
    public void JoinRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }
    #endregion

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        CreatRoom();
    }
    public override void OnJoinedRoom()
    {
        Debug.Log("Welcome" + PhotonNetwork.NickName + " to " + PhotonNetwork.CurrentRoom.Name);
        PhotonNetwork.LoadLevel(1);
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("Welcome" + newPlayer.NickName + " to " + PhotonNetwork.CurrentRoom.Name);
    }
    void CreatRoom()
    {
        Debug.Log("Creating new room");
        string roomName = "Room " + Random.Range(1, 100).ToString();
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.IsOpen = true;
        roomOptions.IsVisible = true;
        PhotonNetwork.CreateRoom(roomName, roomOptions);
    }
}
