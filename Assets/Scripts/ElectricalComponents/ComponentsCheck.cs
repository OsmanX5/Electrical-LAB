using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentsCheck 
{
    public static bool IsConnectedToBattery(Load load)
    {
        int Point1ID = load.GetPoints()[0].ID;
        int Point2ID = load.GetPoints()[1].ID;
        var allPathes = GameManger.GraphManger.GetAllPathesOfBatteryIDs();
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
