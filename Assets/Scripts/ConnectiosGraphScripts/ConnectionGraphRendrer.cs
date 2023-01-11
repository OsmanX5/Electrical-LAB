using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionGraphRendrer : MonoBehaviour
{
    public GameObject LineRendrerPrefab;
    LineRenderer LRconnection;
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
        for (int i = 0; i < ConnectionGraph.nodesCount; i++)
        {
            GameObject LRGO = Instantiate(LineRendrerPrefab, transform);
            LRconnection = LRGO.GetComponent<LineRenderer>();
            lineRenderers.Add(LRconnection);
        }
    }

    private void RenderConnections()
    {
        
    }
}
