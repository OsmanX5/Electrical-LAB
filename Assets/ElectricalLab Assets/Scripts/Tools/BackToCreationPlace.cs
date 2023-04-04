using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToCreationPlace : MonoBehaviour
{
    Vector3 startPosition;
    Quaternion startRotaion;
    void Start()
    {
        startPosition = transform.position;
        startRotaion = transform.rotation;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            backToPlace();
        }
    }
    void backToPlace()
    {
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;

        transform.position = startPosition;
        transform.rotation = startRotaion;
    }
}
