using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Wiere : MonoBehaviour
{
    public static event Action<LineRenderer> OnConnectionWiereingEnd;
    LineRenderer lr;
    public Transform StartPoint;
    public InputActionReference triggerClicked;
    public bool Holding =false;
    bool IsStartWiring = false;
    bool IsInPoint = false;
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
            other.gameObject.transform.localScale *= 1.1f;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        currentPoint = other.gameObject.GetComponent<Point>();
        if (currentPoint)
        {
            IsInPoint = false;
            other.gameObject.transform.localScale /= 1.1f;
        }
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
        Debug.Log("triggerClicked");
        if (Holding)
        {
            Vector3 newPoint = StartPoint.position;
            if (!IsStartWiring && !IsInPoint) 
                return;
            if (IsInPoint)
            {
                newPoint = currentPoint.transform.position;
                if (!IsStartWiring)
                {
                    lastPoint = currentPoint;

                }
                else
                {
                    ConnectionEnd();

                }
                IsStartWiring = !IsStartWiring;
            }
            WireCalculator.AddPointToLine(lr, newPoint);
        }

    }

    void ConnectionEnd()
    {
        PointsConnector.ConnectNodes(lastPoint.ID, currentPoint.ID);
        Vector3[] points = new Vector3[lr.positionCount];
        for (int i = 0; i < lr.positionCount; i++) points[i] = lr.GetPosition(i);
        PathManger.SetPathBetween(lastPoint.ID, currentPoint.ID, points);
        OnConnectionWiereingEnd?.Invoke(lr);
        lr.positionCount = 1;
    }
}
