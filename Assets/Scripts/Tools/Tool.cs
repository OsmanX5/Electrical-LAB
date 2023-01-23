using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tool : MonoBehaviour
{
    public Material PointOff;
    public Material PointOn;
    public InputActionReference triggerClicked;
    public Point TouchedPoint;
    public bool Holding = false;
    public bool IsInPoint = false;
    public void StartHolding() => Holding = true;
    public void relese() => Holding = false;
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Point>() != null)
        {
            TouchedPoint = other.gameObject.GetComponent<Point>();
            IsInPoint = true;
            PointHoverEffectOn(TouchedPoint);
        }
    }
    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Point>() != null)
        {
            PointHoverEffectOff(TouchedPoint);
            TouchedPoint = null;
            IsInPoint = false;
            
        }
    }
    public void PointHoverEffectOn(Point point)
    {
        point.gameObject.GetComponent<Renderer>().material = PointOn;
    }
    public void PointHoverEffectOff(Point point)
    {
        point.gameObject.GetComponent<Renderer>().material = PointOff;
    }

}
