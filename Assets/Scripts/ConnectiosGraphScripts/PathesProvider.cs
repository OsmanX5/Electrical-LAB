using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectioGraphPathesProvider : ConnectionGraph
{
    public List<List<int>> GetAllPathesOfBattery()
    {
        return graph.GetAllPaths(StartID, EndID);
    }
}
