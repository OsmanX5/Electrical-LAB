using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ConnectionGraphRendrer : MonoBehaviour
{
    public GameObject LRPrefab;
    public event Action<GameObject> CreatedNewLineRendrer;  
    [SerializeField] List<GameObject> lineRenderers = new List<GameObject>();

    private void Start()
    {
        Wierer.OnConnectionWiereingEnd += WirerConnectionRender;
        GameManger.GraphManger.OnPointDeleted += DeletPointFromLines;
    }
    private void WirerConnectionRender(List<Point> PathPoints)
    {
        GameObject temp = Instantiate(LRPrefab, this.transform);
        temp.name = "LineRendrer" + lineRenderers.Count().ToString();
        temp.GetComponent<PathRendrer>().SetPoints(PathPoints);
        lineRenderers.Add(temp);
        CreatedNewLineRendrer?.Invoke(temp);
    }
    private void DeletPointFromLines(Point deletedPoint) {
        foreach (var line in lineRenderers)
        {
            line.GetComponent<PathRendrer>().Remove(deletedPoint);
        }
    }
    
}
