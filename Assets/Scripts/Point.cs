using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point :MonoBehaviour
{

    public int ID { get; set; }
    public Point PairPoint { get; set; }
    public Load ParentLoad { get ; set; }
    private void Awake()
    {
        Initlize();
    }
    private void Start()
    {
        PointsManger.AddPoint(this);
    }
    void Initlize()
    {
        ID = PointsManger.CountID++;
        Debug.Log("Point created with ID: " + ID);
        gameObject.name = "Point " + ID;
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
