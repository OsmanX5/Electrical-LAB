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
        GameManger.GraphManger.StartID = posativePoint.ID;
        GameManger.GraphManger.EndID = negativePoint.ID;
    }

}
