using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadsManger : MonoBehaviour
{
    public static List<Load> Loads = new List<Load>();
    public List<Load> loads;
    private void Start()
    {
        GameManger.GraphManger.OnCircuitClose += LoadsTurningOnControl;
        GameManger.GraphManger.OnCircuitOpen += LoadsTurningOffControl;
    }

    private void LoadsTurningOffControl()
    {
        foreach (Load load in Loads)
        {
            load.TurnOff();
        }
    }

    private void Update()
    {
        loads = Loads;
    }

    public static void AddLoad(Load load)=>Loads.Add(load);
    public static void LoadsTurningOnControl()
    {
        foreach (Load load in Loads)
        {
            if (ComponentsCheck.IsConnectedToBattery(load))
            {
                load.TurnOn();
            }
            else
            {
                load.TurnOff();
            }
        }
    }

    public static void RemoveLoad(Load load)
    {
        Loads.Remove(load);
    }
}
