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
    [SerializeField] GameObject loadObject;
    public GameObject LoadObject { get => loadObject; set=> loadObject = value;  }
    public Point posativePoint;
    public Point negativePoint;
    ILoad loadBehovier;

    private void Start()
    {
        iniciatePoints();
        switch (loadType)
        {
            case LoadType.Lamp:
                loadBehovier = this.GetComponent<Lamp>();
                break;
            case LoadType.Buzzer:
                loadBehovier = new Buzzer();
                break;

            default: break;
        }
        TurnOff();
        LoadsManger.AddLoad(this);
    }
    public void iniciatePoints()
    {
        Debug.Log(" posative point at load "+name);
        posativePoint = Instantiate(PointPrefab, PosativePointPlace).GetComponent<Point>();
        posativePoint.Initlize();
        Debug.Log(" negative point at load " + name);
        negativePoint = Instantiate(PointPrefab, NegativePointPlace).GetComponent<Point>();
        negativePoint.Initlize();
        posativePoint.PairPoint = negativePoint;
        negativePoint.PairPoint = posativePoint;
        Debug.Log(posativePoint.ID +" - "+ negativePoint.ID + "Are pairs now");
        posativePoint.ParentLoad = this;
        negativePoint.ParentLoad = this;
        posativePoint.AddToManger();
        negativePoint.AddToManger();
    }
    public float getResistance()
    {
        return resistance;
    }
    public void TurnOn()
    {
        Debug.Log("Turn" + name + "on");
        
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
