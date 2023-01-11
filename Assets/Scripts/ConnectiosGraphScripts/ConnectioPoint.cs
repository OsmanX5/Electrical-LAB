using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionPoint
{
    public Point point;
    public float resistance;
    public ConnectionPoint(Point point,float resistance)
    {
        this.point = point;
        this.resistance = resistance;
    }
}
