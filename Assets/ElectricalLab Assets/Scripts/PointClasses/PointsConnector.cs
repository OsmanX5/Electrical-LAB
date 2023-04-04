using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.ComponentModel;

public class PointsConnector 
{
    public static void ConnectNodesSeries(List<int> points)
    {
        for (int i = 0; i < points.Count - 1; i++) ConnectNodes(points[i], points[i + 1]);
    }
    public static void ConnectNodesSeries(List<Point> points)
    {
        for (int i = 0; i < points.Count - 1; i++) ConnectNodes(points[i], points[i + 1]);
    }
    
    public static void ConnectNodes(int id1, int id2)
    {
        ConnectNodes(PointsManger.GetPoint(id1), PointsManger.GetPoint(id2));
    }
    public static void ConnectPoints(Point a, Point b,float res)
    {
        Debug.Log("Try connecting" + a.ID + " <=> " + b.ID);
        GameManger.GraphManger.ConnectPoints(a, b,res);
    }
    public static void ConnectNodes(Point a,Point b)
    {
        Debug.Log("Try connecting" + a.ID +" <=> " + b.ID);
        GameManger.GraphManger.ConnectPoints(a, b);
    }
}
