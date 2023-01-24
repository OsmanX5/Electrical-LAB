using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;
public class Wierer : PointInteractiveTool
{
    public static event Action<List<Point>> OnConnectionWiereingEnd;
    
    [SerializeField] Transform StartPoint;
    [SerializeField] GameObject PointPrefab;

    List<Vector3> WieringPositions = new List<Vector3>();
    LineRenderer lr;
    Point FirstWiringPoint;
    bool IsStartWiring = false;

    void Start()
    {
        lr = this.GetComponent<LineRenderer>();
        triggerClicked.action.started += WirerClicked;
    }

    private void FixedUpdate()
    {
        if (IsStartWiring)
        {
            lr.SetPosition(lr.positionCount - 1, StartPoint.position);
        }
        if (!Holding && IsStartWiring)
        {
            clear();
        }
    }

    void WirerClicked(InputAction.CallbackContext context)
    {
        if (!Holding) return;
        if (!IsStartWiring && !IsInPoint) return;
        if (IsInPoint)
        {
            // this is the first point
            if (!IsStartWiring) startWiring();
            else  EndWiring();
            return;
        }
        Vector3 NewClickedPosition = StartPoint.position;
        WieringPositions.Add(NewClickedPosition);
        LineRendrerOperator.AddPointToLine(lr, NewClickedPosition);
        lr.positionCount++;
    }

    void startWiring()
    {
        IsStartWiring = true;
        FirstWiringPoint = TouchedPoint;
        lr.positionCount = 2;
        lr.SetPosition(0, TouchedPoint.transform.position);
    }
    void EndWiring()
    {
        
        IsStartWiring = false;
        List<Point> createdPoints = GetTheWiringPoints();
        PointsConnector.ConnectNodesSeries(createdPoints);
        OnConnectionWiereingEnd?.Invoke(createdPoints);
        FirstWiringPoint = null;
        TouchedPoint = null;
        lr.positionCount = 0;
        lr.positionCount = 1;
    }
    List<Point> GetTheWiringPoints()
    {
        List<Point> PathPoints = new List<Point>();
        PathPoints.Add(FirstWiringPoint);
        List<NodePoint> NodesPoints =  NodePointsCreator.BuildePoints(WieringPositions, PointPrefab);
        PathPoints.AddRange(NodesPoints);
        PathPoints.Add(TouchedPoint);
        return PathPoints;
    }
    void clear()
    {
        IsStartWiring = false;
        lr.positionCount = 0;
        WieringPositions = new List<Vector3>();
        FirstWiringPoint = null;
    }


}
