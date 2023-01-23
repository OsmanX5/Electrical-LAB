using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class ConnectionGraph : MonoBehaviour
{
    public  ElectricalGraph Graph;
    public  int StartID;
    public  int EndID;
    
    private void Awake()
    {
        Graph = new ElectricalGraph();
    }

    
}
