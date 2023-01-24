using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricalComponent : MonoBehaviour
{
    [SerializeField] protected Transform PosativePointPlace;
    [SerializeField] protected Transform NegativePointPlace;
    [SerializeField] protected GameObject PointPrefab;
    protected ComponentPoint posativePoint;
    protected ComponentPoint negativePoint;
    protected void IniciatePoints()
    {
        posativePoint = Instantiate(PointPrefab, PosativePointPlace).GetComponent<ComponentPoint>();
        posativePoint.Initlize();
        negativePoint = Instantiate(PointPrefab, NegativePointPlace).GetComponent<ComponentPoint>();
        negativePoint.Initlize();
        posativePoint.ElectricalComponent = this;
        negativePoint.ElectricalComponent = this;
    }
    public Point[] GetPoints() => new Point[] { posativePoint, negativePoint };

}
