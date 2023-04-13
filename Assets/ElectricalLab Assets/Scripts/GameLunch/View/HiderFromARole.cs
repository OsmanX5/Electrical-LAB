using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiderFromARole : MonoBehaviour
{
    [SerializeField] UserRole HideFrom;
	void OnEnable()
    {
        if (UserProfile.UserRole == HideFrom)
        {
			gameObject.SetActive(false);
		}
        else
            gameObject.SetActive(true);
    }
}
