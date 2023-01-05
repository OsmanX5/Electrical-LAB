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
    void AddPointToConnection(Point point)
    {
        ConnectedPoints.Add(point);
    }

}
