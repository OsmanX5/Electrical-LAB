using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectioGraphPathesProvider : ConnectionGraphBuilder
{
    public List<List<int>> GetAllPathesOfBattery()
    {
        return Graph.GetAllPaths(StartID, EndID);
    }
    public string GetPathesOfBatterySTR() {
        string res = "Pathes : \n";
        res += Graph.GetAllPathesSTR(StartID, EndID);
        return res;
    }
}
