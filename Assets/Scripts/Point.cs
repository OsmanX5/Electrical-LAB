using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point :MonoBehaviour
{
    static int PointsCountID = 0;
    public static List<Point> Points = new List<Point>();
    public int ID { get; set; }
    public Point PairPoint { get; set; }
    public Load ParentLoad { get ; set; }
    public event Action<Point> OnPointCreated;
    private void Awake()
    {
        ID = PointsCountID++;
        Debug.Log("Point created with ID: " + ID);
        gameObject.name = "Point " + ID;
        Points.Add(this);
    }
    void Start()
    {
        OnPointCreated?.Invoke(this);
    }

    public static bool operator ==(Point a, Point b)
    {
        return a.ID == b.ID;
    }
    public static bool operator !=(Point a, Point b)
    {
        return !(a==b);
    }
}
