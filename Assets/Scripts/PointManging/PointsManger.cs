using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class PointsManger : MonoBehaviour
{
    public static int CountID = 0;
    public static Dictionary<int,Point> Points = new Dictionary<int, Point>();
    public static Point GetPointByID(int id) => Points[id];
    public static void AddPoint(Point point)
    {
        Points[point.ID] = point;
        GameManger.GraphManger.AddNewPoint(point);
    }
    public static void RemovePoint(Point point)
    {
        Points.Remove(point.ID);
    }
}
