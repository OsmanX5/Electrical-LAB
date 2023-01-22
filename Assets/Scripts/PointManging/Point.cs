using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public int ID { get; set; }
    public virtual void Initlize()
    {
        ID = PointsManger.CountID++;
        transform.name = "Point " + ID; 
        PointsManger.AddPoint(this);
    }
}
