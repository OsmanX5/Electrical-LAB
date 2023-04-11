using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PhotonNickNamer : MonoBehaviour
{
	TMPro.TMP_InputField inputField;
	public void UpdatePhotonNickName()
	{
		inputField = GetComponent<TMPro.TMP_InputField>();
		if (inputField == null)
		{
			Debug.LogError("NickName Inputfield is null");
			return;
		}

		PhotonNetwork.NickName = inputField.text;
	}
}