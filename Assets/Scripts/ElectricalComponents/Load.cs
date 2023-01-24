using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : ElectricalComponent
{
    [SerializeField] float resistance = 10f;
    private void Start()
    {
        InitiateLoad();
    }
    protected void InitiateLoad()
    {
        IniciatePoints();
        PointsConnector.ConnectPoints(posativePoint, negativePoint, resistance);
        LoadsManger.AddLoad(this);
    }
    public virtual void TurnOn() {
        Debug.Log("Load is on");
    }
    public virtual void TurnOff() { }

}
