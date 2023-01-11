using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionGraphRendrer : MonoBehaviour
{
    public GameObject LRPrefab;
    List<LineRenderer> lineRenderers = new List<LineRenderer>();
    private void Start()
    {
        CreateLineRendrers();
    }
    void FixedUpdate()
    {
        RenderConnections();
    }

    private void CreateLineRendrers()
    {
        int needed = ConnectionGraph.DisJointSet.JointsCount;
    }

    private void RenderConnections()
    {
        
    }
}
