using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveComponent : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Floor")
        {
            Destroy(this.gameObject);
        }
    }
    private void OnDestroy()
    {
        
    }
}
