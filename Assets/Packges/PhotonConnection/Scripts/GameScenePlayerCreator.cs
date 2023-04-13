using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameScenePlayerCreator : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject OnlinePlayerPrefab;
    [SerializeField] GameObject OfflinePlayerPrefab;
    public void Start()
    {
        if(UserProfile.PlayMode == PlayMode.Online)
        {
			PhotonNetwork.Instantiate(OnlinePlayerPrefab.name, new Vector3(Random.Range(-2, 2), 0, -2), Quaternion.identity);
		}
		else
        {
			Instantiate(OfflinePlayerPrefab, new Vector3(Random.Range(-2, 2), 0, -2), Quaternion.identity);
		}
    }
}
