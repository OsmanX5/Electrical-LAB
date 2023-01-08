using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    int static PointsCountID = 0;
    [SerializeField] float Voltage { get; set; }
    int ID { get; }
    List<Point> ConnectedPoints;
    
    Point(){
        ID = PointsCountID++;
        ConnectedPoints = new List<Point>();
    }

    
    public void ConnectToPoint(Point point)
    {
        ConnectedPoints.Add(point);
    }
}
