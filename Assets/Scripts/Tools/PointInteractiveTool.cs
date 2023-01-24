using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointInteractiveTool : Tool
{
    public Material PointOff;
    public Material PointOn;
    public bool IsInPoint = false;
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
        if (other.gameObject.GetComponent<Point>() == TouchedPoint)
        {
            PointHoverEffectOff(TouchedPoint);
            TouchedPoint = null;
            IsInPoint = false;
        }
    }
    public void PointHoverEffectOn(Point point)
    {
        if (point != null)
            point.gameObject.GetComponent<Renderer>().material = PointOn;
    }
    public void PointHoverEffectOff(Point point)
    {
        if (point != null)
            point.gameObject.GetComponent<Renderer>().material = PointOff;
    }
}
