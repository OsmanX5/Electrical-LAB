using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : ILoad
{
    
    public  void TurnOn()
    {
        Debug.Log("Light is On");
        throw new System.NotImplementedException();
    }
    public  void TurnOff()
    {
        Debug.Log("Light is Off");
        throw new System.NotImplementedException();
    }

    public string GetLoadType()
    {
        return LoadType.Lamp.ToString();
        throw new System.NotImplementedException();
    }
}
