using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectioGraphPathesProvider : ConnectionGraphBuilder
{
    public List<List<int>> GetAllPathesOfBatteryIDs()
    {
        return Graph.UWGraph.GetAllPaths(StartID, EndID);
    }
    public List<List<Point>> GetAllPathesOfBattery()
    {
        List<List<int>> pathes = GetAllPathesOfBatteryIDs();
        List<List<Point>> res = new();
        foreach (var path in pathes)
        {
            List<Point> resPath = new();
            foreach (var point in path)
            {
                resPath.Add(PointsManger.GetPoint(point));
            }
            res.Add(resPath);
        }
        return res;
    }
    public string GetPathesOfBatterySTR() {
        string res = "Pathes : \n";
        res += Graph.UWGraph.GetAllPathesSTR(StartID, EndID);
        return res;
    }
}
