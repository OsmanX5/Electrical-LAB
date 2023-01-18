using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point :MonoBehaviour
{

    public int ID { get; set; }
    public Point? PairPoint { get; set; }
    public Load? ParentLoad { get ; set; }
    public void Initlize()
    {
        ID = PointsManger.CountID++;
        Debug.Log("Point created with ID: " + ID);
        gameObject.name = "Point " + ID;
        ParentLoad = null;
        AddToManger();
    }
    public void AddToManger()
    {
        PointsManger.AddPoint(this);
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
