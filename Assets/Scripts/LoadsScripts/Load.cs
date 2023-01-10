using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Load : MonoBehaviour,ILoad
{
    [SerializeField] float resistance = 10f;
    [SerializeField] LoadType loadType;
    [SerializeField] Transform PosativePointPlace;
    [SerializeField] Transform NegativePointPlace;
    [SerializeField] GameObject PointPrefab;
    Point posativePoint;
    Point negativePoint;
    ILoad loadBehovier;

    private void Start()
    {
        iniciatePoints();
        switch (loadType)
        {
            case LoadType.Lamp: 
                loadBehovier = new Lamp();
                break;
            case LoadType.Buzzer:
                loadBehovier = new Buzzer();
                break;

            default: break;
        }
    }
    public void iniciatePoints()
    {
        posativePoint = Instantiate(PointPrefab, PosativePointPlace).GetComponent<Point>();
        negativePoint = Instantiate(PointPrefab, NegativePointPlace).GetComponent<Point>();
        posativePoint.PairPoint = negativePoint;
        negativePoint.PairPoint = posativePoint;
        posativePoint.ParentLoad = this;
        negativePoint.ParentLoad = this;
    }
    public float getResistance()
    {
        return resistance;
    }
    public void TurnOn()
    {
        loadBehovier.TurnOn();
    }
    public void TurnOff()
    {
        loadBehovier.TurnOff();
    }
    public string GetLoadType()
    {
        return loadType.ToString();
    }
}
