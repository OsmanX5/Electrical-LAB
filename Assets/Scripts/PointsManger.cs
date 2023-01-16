using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class PointsManger : MonoBehaviour
{
    public static List<Point> Points = new List<Point>();
    public static int CountID = 0;
    public static void AddPoint(Point point)
    {
        Points.Add(point);
        ConnectionGraphBuilder.AddNewPoint(point);
    }
    public static Point GetPointByID(int id)=>Points[id];
    public static Point[] GetConnectedPointsToID(int id)
    {
        int[] pointsId = ConnectionGraph.DisJointSet.GetJointPoints(id);
        Point[] points = (from pointId in pointsId select PointsManger.GetPointByID(pointId)).ToArray();
        return points;
    }

}
