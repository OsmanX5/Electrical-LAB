using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : ElectricalComponent
{
    [SerializeField] float resistance = 10f;
    private void Start()
    {
        iniciatePoints();
        PointsConnector.ConnectPoints(posativePoint, negativePoint, resistance);
        LoadsManger.AddLoad(this);
    }
    public virtual void TurnOn() { }
    public virtual void TurnOff() { }

}
