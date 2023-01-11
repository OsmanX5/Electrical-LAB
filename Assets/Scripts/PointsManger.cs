using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManger : MonoBehaviour
{
    public static List<Point> Points = new List<Point>();
    public static int CountID = 0;
    public static void AddPoint(Point point)
    {
        Points.Add(point);
        ConnectionGraphBuilder.AddNewPoint(point);
    }
    public static Point GetPointWithID(int id)=>Points[id];

}
