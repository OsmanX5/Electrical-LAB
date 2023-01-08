using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectioPoint
{
    Point point;
    float resistance;
    public ConnectioPoint(Point point,float resistance)
    {
        this.point = point;
        this.resistance = resistance;
    }
}
