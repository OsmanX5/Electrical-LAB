using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerSource : ElectricalComponent
{
    public float voltage;
    void Start()
    {
        InitiatePowerSource();
    }
    protected void InitiatePowerSource()
    {
        IniciatePoints();
        GameManger.GraphManger.StartID = posativePoint.ID;
        GameManger.GraphManger.EndID = negativePoint.ID;
    }
}