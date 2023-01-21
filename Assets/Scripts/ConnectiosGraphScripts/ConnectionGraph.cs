using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class ConnectionGraph : MonoBehaviour
{
    public static ElectricalGraph graph;
    public static ConnectionGraphBuilder builder;
    public static ConnectionGraphChecker checker;
    public static ConnectioGraphPathesProvider pathesProvider;
    public static int StartID;
    public static int EndID;
    private void Awake()
    {
        graph = new ElectricalGraph();
        builder = new ConnectionGraphBuilder();
        checker = new ConnectionGraphChecker();
        pathesProvider = new ConnectioGraphPathesProvider();
    }
    
}
