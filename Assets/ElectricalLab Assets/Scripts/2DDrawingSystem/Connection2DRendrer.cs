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
        ClonedLineRendrers = new List<GameObject>();
        Rendrer3D.CreatedNewLineRendrer += AddNewRendrer;
    }

    public void AddNewRendrer(GameObject obj)
    {
        GameObject temp2DRendrer = Instantiate(LRPrefab2D, this.transform);
        temp2DRendrer.GetComponent<PathRendrer2D>().SetPoints(obj.GetComponent<PathRendrer>().points);
        ClonedLineRendrers.Add(temp2DRendrer);
    }
}
