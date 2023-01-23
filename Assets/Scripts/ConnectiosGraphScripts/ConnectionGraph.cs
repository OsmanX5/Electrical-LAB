using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class ConnectionGraph : MonoBehaviour
{
    public  ElectricalGraph graph;
    public  int StartID;
    public  int EndID;
    
    private void Awake()
    {
        graph = new ElectricalGraph();
    }

    
}
