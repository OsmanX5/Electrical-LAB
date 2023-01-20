using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadsManger : MonoBehaviour
{
    public static List<Load> Loads = new List<Load>();
    public List<Load> loads;
    private void Start()
    {
        ConnectionGraphPathCalculator.OnCircuitClose += LoadsTurningOnControl;
    }
   
    private void Update()
    {
        loads = Loads;
    }

    public static void AddLoad(Load load)=>Loads.Add(load);
    public static void LoadsTurningOnControl()
    {
        Debug.Log("I know circuit close");
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
}
