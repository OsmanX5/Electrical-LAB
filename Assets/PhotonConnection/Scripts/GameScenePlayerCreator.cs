using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameScenePlayerCreator : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject PlayerPrefab;
    public void Start()
    {
        PhotonNetwork.Instantiate(PlayerPrefab.name,new Vector3(Random.Range(-2,2),0,-2),Quaternion.identity);
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
    }
}
