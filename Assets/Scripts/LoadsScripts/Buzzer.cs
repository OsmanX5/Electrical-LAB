using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buzzer : MonoBehaviour, ILoad
{
    public string GetLoadType()
    {
        return LoadType.Buzzer.ToString();
        throw new System.NotImplementedException();
    }

    public void TurnOff()
    {
        Debug.Log("Buzzer Is On");
        throw new System.NotImplementedException();
    }

    public void TurnOn()
    {

        Debug.Log("Buzzer Is off");
        throw new System.NotImplementedException();
    }
}
