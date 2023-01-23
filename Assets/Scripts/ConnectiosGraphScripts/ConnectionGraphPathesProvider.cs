using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectioGraphPathesProvider : ConnectionGraphBuilder
{
    public List<List<int>> GetAllPathesOfBattery()
    {
        return Graph.GetAllPaths(StartID, EndID);
    }
}
