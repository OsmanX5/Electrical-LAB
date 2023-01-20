using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricalComponent : MonoBehaviour
{
    [SerializeField] protected Transform PosativePointPlace;
    [SerializeField] protected Transform NegativePointPlace;
    [SerializeField] protected GameObject PointPrefab;
    protected Point posativePoint;
    protected Point negativePoint;
    public void iniciatePoints()
    {
        posativePoint = Instantiate(PointPrefab, PosativePointPlace).GetComponent<Point>();
        posativePoint.Initlize();
        negativePoint = Instantiate(PointPrefab, NegativePointPlace).GetComponent<Point>();
        negativePoint.Initlize();
        posativePoint.ElectricalComponent = this;
        negativePoint.ElectricalComponent = this;
    }
    public Point[] GetPoints() => new Point[] { posativePoint, negativePoint };

}
