using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    [SerializeField] float Voltage { get; }
    List<Point> ConnectedPoints;
    private void Start()
    {
        
    }
    public List<Point> GetConnectedPoints;
    public void ConnectToPoint(Point point)
    {
        ConnectedPoints.Add(point);
    }

    public int Compare(Point x, Point y)
    {
        throw new System.NotImplementedException();
    }
}
