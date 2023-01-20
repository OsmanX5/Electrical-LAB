using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : Load
{
    [SerializeField] Material offMaterial;
    [SerializeField] Material onMaterial;
    [SerializeField] GameObject LightingBulb;

    public override void TurnOn()
    {
        Debug.Log("Light is On");
        LightingBulb.GetComponent<Renderer>().material = onMaterial;
    }
    public override void TurnOff()
    {
        LightingBulb.GetComponent<Renderer>().material = offMaterial;
        Debug.Log("Light is Off");
    }


}
