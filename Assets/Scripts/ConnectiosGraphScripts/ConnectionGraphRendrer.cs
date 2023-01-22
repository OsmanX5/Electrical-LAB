using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ConnectionGraphRendrer : MonoBehaviour
{
    public GameObject LRPrefab;
    [SerializeField] List<GameObject> lineRenderers = new List<GameObject>();

    private void Start()
    {
        Wierer.OnConnectionWiereingEnd += WirerConnectionRender;
        ConnectionGraph.builder.OnPointDeleted += DeletPointFromLines;
    }
    private void WirerConnectionRender(List<Point> PathPoints)
    {
        GameObject temp = Instantiate(LRPrefab, this.transform);
        temp.name = "LineRendrer" + lineRenderers.Count().ToString();
        temp.GetComponent<PathRendrer>().points = PathPoints;
        lineRenderers.Add(temp);        
    }
    private void DeletPointFromLines(Point deletedPoint) {
        Debug.Log("deleting from rendrer" + deletedPoint.ID);
        foreach (var line in lineRenderers)
        {
            line.GetComponent<PathRendrer>().Remove(deletedPoint);
        }
    }
    
}
