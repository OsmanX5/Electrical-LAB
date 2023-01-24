using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionGraphManger : ConnectionGraphChecker
{
    public ConnectionGraphManger(){
        Graph = new ElectricalGraph();
    }
}
