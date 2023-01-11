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

    public static bool operator ==(ConnectionPoint a, ConnectionPoint b)
    {
        return (a.point == b.point) && (a.resistance == b.resistance);
    }
    public static bool operator !=(ConnectionPoint a, ConnectionPoint b)
    {
        return !(a==b);
    }
}
