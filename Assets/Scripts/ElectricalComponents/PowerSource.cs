using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerSource : ElectricalComponent
{
    [SerializeField] float voltage;
    private void Awake()
    {
        this.AddComponent<ElectronEmmitingManger>();
    }
    void Start()
    {
        iniciatePoints();
        ConnectionGraph.StartID = posativePoint.ID;
        ConnectionGraph.EndID = negativePoint.ID;
    }

}
