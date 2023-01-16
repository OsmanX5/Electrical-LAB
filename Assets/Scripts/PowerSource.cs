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
        Debug.Log(" posative point at Power " + name);
        posativePoint = Instantiate(PointPrefab, PosativePointPlace).GetComponent<Point>();
        posativePoint.Initlize();
        Debug.Log(" negative point at Power " + name);
        negativePoint = Instantiate(PointPrefab, NegativePointPlace).GetComponent<Point>();
        negativePoint.Initlize(); 
        posativePoint.PairPoint = negativePoint;
        negativePoint.PairPoint = posativePoint;
        Debug.Log(posativePoint.ID + " - " + negativePoint.ID + "Are pairs now");
        ConnectionGraph.StartID = posativePoint.ID;
        ConnectionGraph.EndID = negativePoint.ID;
        posativePoint.AddToManger();
        negativePoint.AddToManger();

    }

}
