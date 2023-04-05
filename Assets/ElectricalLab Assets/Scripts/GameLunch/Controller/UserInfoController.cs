using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class UserInfoController : MonoBehaviour
{
    public int MyProperty { get; set; }
    public void SetUserName(string x)
    {
        PhotonNetwork.NickName = x;
    }
}
