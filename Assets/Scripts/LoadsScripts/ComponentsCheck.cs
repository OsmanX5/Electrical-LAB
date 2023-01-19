using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentsCheck 
{
    public static bool IsConnectedToBattery(ILoad load)
    {
        int Point1ID = load.GetPoints()[0].ID;
        int Point2ID = load.GetPoints()[1].ID;
        var allPathes = ConnectionGraphPathCalculator.AllPathesOfBattery;
        foreach (var path in allPathes)
        {
            if (path.Contains(Point1ID) && path.Contains(Point2ID))
            {
                return true;
            }
        }
        return false;
    }
}
