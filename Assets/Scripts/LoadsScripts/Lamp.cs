using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour, ILoad
{
    [SerializeField] float resistance = 10f;
    [SerializeField] Transform PosativePointPlace;
    [SerializeField] Transform NegativePointPlace;
    [SerializeField] GameObject PointPrefab;
    [SerializeField] Material offMaterial;
    [SerializeField] Material onMaterial;
    [SerializeField] GameObject LightingBulb;
    Point posativePoint;
    Point negativePoint;

    private void Start()
    {
        iniciatePoints();
        TurnOff();
        LoadsManger.AddLoad(this);
    }
    public void iniciatePoints()
    {
        posativePoint = Instantiate(PointPrefab, PosativePointPlace).GetComponent<Point>();
        posativePoint.Initlize();
        negativePoint = Instantiate(PointPrefab, NegativePointPlace).GetComponent<Point>();
        negativePoint.Initlize();
        posativePoint.ElectricalComponent = this;
        negativePoint.ElectricalComponent = this;
        PointsConnector.ConnectPoints(posativePoint, negativePoint, resistance);
    }
    public void TurnOn()
    {
        Debug.Log("Light is On");
        LightingBulb.GetComponent<Renderer>().material = onMaterial;
    }
    public void TurnOff()
    {
        LightingBulb.GetComponent<Renderer>().material = offMaterial;
        Debug.Log("Light is Off");
    }

    public Point[] GetPoints() => new Point[] { posativePoint, negativePoint };

}
