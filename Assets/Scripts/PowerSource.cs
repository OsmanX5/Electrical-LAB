using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerSource : MonoBehaviour, IElectricalComponent
{
    [SerializeField] float voltage;
    [SerializeField] Transform PosativePointPlace;
    [SerializeField] Transform NegativePointPlace;
    [SerializeField] GameObject PointPrefab;
    Point posativePoint;
    Point negativePoint;
    private void Awake()
    {
        this.AddComponent<ElectronEmmitingManger>();
    }
    void Start()
    {
        iniciatePoints();
    }
    public void iniciatePoints()
    {
        posativePoint = Instantiate(PointPrefab, PosativePointPlace).GetComponent<Point>();
        posativePoint.Initlize();
        negativePoint = Instantiate(PointPrefab, NegativePointPlace).GetComponent<Point>();
        negativePoint.Initlize(); 
        ConnectionGraph.StartID = posativePoint.ID;
        ConnectionGraph.EndID = negativePoint.ID;

    }

}
