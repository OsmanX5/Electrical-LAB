using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connection2DRendrer : MonoBehaviour
{
    public GameObject LRPrefab2D;
    public ConnectionGraphRendrer Rendrer3D;
    List<GameObject> ClonedLineRendrers;
    void Start()
    {
        Rendrer3D.CreatedNewLineRendrer += AddNewRendrer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddNewRendrer(GameObject obj)
    {
        GameObject temp = Instantiate(LRPrefab2D, this.transform);
        ClonedLineRendrers.Add(temp);
    }
}
