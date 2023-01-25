using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentPoint : Point
{
    public ElectricalComponent ElectricalComponent { get; set; }
    public Point PairPoint { get; set; }
    public override void Initlize()
    {
        base.Initlize();
        transform.parent.name = "ComponentPoint " + ID;
        transform.parent.parent.name += "_" +ID.ToString() +"_";
    }
}
