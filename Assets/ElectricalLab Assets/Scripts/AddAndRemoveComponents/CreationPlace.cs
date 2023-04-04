using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreationPlace : MonoBehaviour
{
    public List<GameObject> ObjectsInPlace;
    // Start is called before the first frame update
    void Start()
    {
        ObjectsInPlace = new();
    }

    private void OnTriggerEnter(Collider other)
    {
        ObjectsInPlace.Add(other.gameObject);
    }
    private void OnTriggerExit(Collider other)
    {
        ObjectsInPlace.Remove(other.gameObject);
    }
    public bool IsPlaceIsEmpty() => ObjectsInPlace.Count == 0;

}
