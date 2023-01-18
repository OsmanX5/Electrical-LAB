using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ConnectionGraphRendrer : MonoBehaviour
{
    public GameObject LRPrefab;
    [SerializeField] List<GameObject> lineRenderers = new List<GameObject>();

    private void Awake()
    {
        Wierer.OnConnectionWiereingEnd += WirerConnectionRender;
    }
    private void WirerConnectionRender(List<Point> PathPoints)
    {
        GameObject temp = Instantiate(LRPrefab, this.transform);
        temp.name = "LineRendrer" + lineRenderers.Count().ToString();
        temp.GetComponent<PathRendrer>().points = PathPoints;
        lineRenderers.Add(temp);        
    }
    
}
