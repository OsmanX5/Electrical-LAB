using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResistorEdge 
{
    public int id1;
    public int id2;
    public float Resistance;
    public ResistorEdge(int id1, int id2, float Resistance)
    {
        this.id1 = id1;
        this.id2 = id2;
        this.Resistance = Resistance;
    }
}
