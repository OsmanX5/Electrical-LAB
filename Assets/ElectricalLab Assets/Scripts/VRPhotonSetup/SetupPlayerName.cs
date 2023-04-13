using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupPlayerName : MonoBehaviourPun
{
    // Start is called before the first frame update
    void Start()
    {
        photonView.RPC("SetName", RpcTarget.AllBuffered, PhotonNetwork.NickName);
		photonView.RPC("SayHelloToAll", RpcTarget.AllBuffered, PhotonNetwork.NickName);
    }
    [PunRPC]
    public void SetName(string name)
    {
		this.name = name;
	}
    [PunRPC]
    public void SayHelloToAll(string name)
    {
        Debug.Log("Say hello to "+name);
    }

}
