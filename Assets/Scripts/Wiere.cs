using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;
public class Wierer : MonoBehaviour
{
    public static event Action<List<Point>> OnConnectionWiereingEnd;
    
    public Transform StartPoint;
    public InputActionReference triggerClicked;
    public GameObject PointPrefab;
    public Material PointOff;
    public Material PointOn; 
    
    bool IsStartWiring = false;
    bool IsInPoint = false;
    bool Holding = false;
    LineRenderer lr;
    Point lastPoint,currentPoint;
    
    void Start()
    {
        lr = this.GetComponent<LineRenderer>();
        lr.positionCount = 1;
        triggerClicked.action.started += addThePoint;
    }
    public void StartHolding()=> Holding = true;
    public void relese()=>Holding = false;

    private void OnTriggerEnter(Collider other)
    {
        currentPoint = other.gameObject.GetComponent<Point>();
        if (currentPoint)
        {
            IsInPoint = true;
            PointHoverEffectOn(currentPoint);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        currentPoint = other.gameObject.GetComponent<Point>();
        if (currentPoint)
        {
            IsInPoint = false;
            PointHoverEffectOff(currentPoint);
        }
    }

    public void PointHoverEffectOn(Point point)
    {
        point.gameObject.transform.localScale *= 1.3f;
        point.gameObject.GetComponent<Renderer>().material = PointOn;
    }
    public void PointHoverEffectOff(Point point)
    {
        point.gameObject.transform.localScale /= 1.3f;
        point.gameObject.GetComponent<Renderer>().material = PointOff;
    }
    private void FixedUpdate()
    {
        if (IsStartWiring)
        {
            lr.SetPosition(lr.positionCount - 1, StartPoint.position);
        }
    }

    void addThePoint(InputAction.CallbackContext context)
    {
        if (Holding)
        {
            Vector3 newPoint = StartPoint.position;
            if (!IsStartWiring && !IsInPoint) 
                return;
            if (IsInPoint)
            {
                newPoint = currentPoint.transform.position;
                if (!IsStartWiring) lastPoint = currentPoint;
                else
                {
                    ConnectionEnd();
                    return;
                }
                IsStartWiring = !IsStartWiring;
            }
            WireCalculator.AddPointToLine(lr, newPoint);
        }
    }

    void ConnectionEnd()
    {
        IsStartWiring = false;
        List<Point> createdPoints = GetTheWiringPoints();
        PointsConnector.ConnectNodesSeries(createdPoints);
        OnConnectionWiereingEnd?.Invoke(createdPoints);
        lr.positionCount = 0;
        lr.positionCount = 1;
    }
    List<Point> GetTheWiringPoints()
    {
        List<Point> PathPoints = new List<Point>();
        PathPoints.Add(lastPoint);
        for (int i = 1; i < lr.positionCount - 1; i++)
        {
            Point newPoint = Instantiate(PointPrefab, lr.GetPosition(i), Quaternion.identity).GetComponent<Point>();
            newPoint.Initlize();
            PathPoints.Add(newPoint);
        }
        PathPoints.Add(currentPoint);
        return PathPoints;
    }
}
