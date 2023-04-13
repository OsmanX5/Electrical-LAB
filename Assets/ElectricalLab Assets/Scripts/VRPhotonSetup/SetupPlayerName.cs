using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupPlayerName : MonoBehaviourPun
{
	public TMPro.TMP_Text NameText;

	void Start()
    {
		photonView.RPC("SetName", RpcTarget.AllBuffered, PhotonNetwork.NickName);
		photonView.RPC("SayHelloToAll", RpcTarget.AllBuffered, PhotonNetwork.NickName);

    }
    [PunRPC]
    public void SetName(string name)
    {
		this.name = name;
        NameText.text = name;
	}
    [PunRPC]
    public void SayHelloToAll(string name)
    {
        Debug.Log("Say hello to "+name);
    }

}
