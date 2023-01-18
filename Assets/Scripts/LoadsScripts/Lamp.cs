using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour, ILoad
{
    public Material offMaterial;
    public Material onMaterial;
    public GameObject LightingBulb;
    public void TurnOn()
    {
        Debug.Log("Light is On");
        LightingBulb.GetComponent<Renderer>().material = onMaterial;
    }
    public void TurnOff()
    {
        LightingBulb.GetComponent<Renderer>().material = offMaterial;
        Debug.Log("Light is Off");
    }

    public string GetLoadType()
    {
        return LoadType.Lamp.ToString();
        throw new System.NotImplementedException();
    }
}
