using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class ConnectionGraph : MonoBehaviour
{
    public static ElectricalGraph graph;
    public static int StartID;
    public static int EndID;
    private void Awake()
    {
        graph = new ElectricalGraph();
        this.AddComponent<ConnectionGraphBuilder>();
        this.AddComponent<ConnectionGraphPathCalculator>();
    }
    
}
