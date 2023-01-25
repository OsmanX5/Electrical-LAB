using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Load : ElectricalComponent
{
    [SerializeField] protected float resistance;
    public float Resistance { get =>resistance; set => resistance = value; }
    private void Start()
    {
        InitiateLoad();
    }
    protected void InitiateLoad()
    {
        IniciatePoints();
        posativePoint.PairPoint = negativePoint;
        negativePoint.PairPoint = posativePoint;
        PointsConnector.ConnectPoints(posativePoint, negativePoint, Resistance);
        LoadsManger.AddLoad(this);
        this.AddComponent<RemoveComponent>();
    }
    public virtual void TurnOn() {
        Debug.Log("Load is on");
    }
    public virtual void TurnOff() { }

    public virtual void OnDestroy()
    {
        LoadsManger.RemoveLoad(this);
        GameManger.GraphManger.RemovePoint(posativePoint);
        GameManger.GraphManger.RemovePoint(negativePoint);
    }
}
