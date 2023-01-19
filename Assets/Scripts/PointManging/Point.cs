using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point :MonoBehaviour
{
    public int ID { get; set; }
    public IElectricalComponent ElectricalComponent { get ; set; }
    public void Initlize()
    {
        ID = PointsManger.CountID++;
        transform.name = "Point " + ID;
        ElectricalComponent = null;
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
