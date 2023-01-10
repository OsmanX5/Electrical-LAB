using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point :MonoBehaviour
{
    static int PointsCountID = 0;
    int ID { get;}
    
    List<Point> ConnectedPoints;
    public Point PairPoint { get; set; }
    public ILoad ParentLoad { get; set; }
    public Point()
    {
        ID = PointsCountID++;
        Debug.Log("Point created with ID: " + ID);
        ConnectedPoints = new List<Point>();
    }

    public List<Point> GetConnectedPoints()
    {
        return ConnectedPoints;
    }
    public void ConnectToPoint(Point point)
    {
        ConnectedPoints.Add(point);
    }
    public void DisconnectFromPoint(Point point)
    {
        ConnectedPoints.Remove(point);
    }

}
