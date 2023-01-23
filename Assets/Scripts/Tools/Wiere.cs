using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;
public class Wierer : Tool
{
    public static event Action<List<Point>> OnConnectionWiereingEnd;
    
    public Transform StartPoint;
    public GameObject PointPrefab;
    
    public bool IsStartWiring = false;
    LineRenderer lr;
    public Point lastPoint;
    
    void Start()
    {
        lr = this.GetComponent<LineRenderer>();
        lr.positionCount = 1;
        triggerClicked.action.started += addThePoint;
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
            Debug.Log("You are holding");
            Vector3 newPoint = StartPoint.position;
            if (!IsStartWiring && !IsInPoint) 
                return;
            if (IsInPoint)
            {
                Debug.Log("You are in Point");
                Debug.Log("currentPoint: " + TouchedPoint.ID);
                newPoint = TouchedPoint.transform.position;
                Debug.Log("Saved the position");
                if (!IsStartWiring) lastPoint = TouchedPoint;
                else
                {
                    ConnectionEnd();
                    return;
                }
                IsStartWiring = !IsStartWiring;
            }
            LineRendrerOperator.AddPointToLine(lr, newPoint);
        }
    }

    void ConnectionEnd()
    {
        if(lastPoint!=null)
            PointHoverEffectOff(lastPoint);
        if (TouchedPoint != null)
            PointHoverEffectOff(TouchedPoint);
        IsStartWiring = false;
        List<Point> createdPoints = GetTheWiringPoints();
        PointsConnector.ConnectNodesSeries(createdPoints);
        OnConnectionWiereingEnd?.Invoke(createdPoints);
        lastPoint = null;
        TouchedPoint = null;
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
        PathPoints.Add(TouchedPoint);
        return PathPoints;
    }
}
