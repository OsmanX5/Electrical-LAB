using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreationPlace : MonoBehaviour
{
    public List<GameObject> OnPlaceObjects;
    // Start is called before the first frame update
    void Start()
    {
        OnPlaceObjects = new();
    }

    private void OnTriggerEnter(Collider other)
    {
        OnPlaceObjects.Add(other.gameObject);
    }
    private void OnTriggerExit(Collider other)
    {
        OnPlaceObjects.Remove(other.gameObject);
    }
}
