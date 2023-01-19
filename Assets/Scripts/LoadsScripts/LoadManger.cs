using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadsManger : MonoBehaviour
{
    public static List<ILoad> Loads = new List<ILoad>();
    public List<ILoad> loads;
    private void Start()
    {
        ConnectionGraphPathCalculator.OnCircuitClose += LoadsTurningOnControl;
    }
   
    private void Update()
    {
        loads = Loads;
    }

    public static void AddLoad(ILoad load)=>Loads.Add(load);
    public static void LoadsTurningOnControl()
    {
        Debug.Log("I know circuit close");
        foreach (ILoad load in Loads)
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
