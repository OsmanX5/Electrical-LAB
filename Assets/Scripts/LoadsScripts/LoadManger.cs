using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadsManger : MonoBehaviour
{
    public static List<Load> Loads = new List<Load>();
    public List<Load> loads;
    private void Update()
    {
        loads = Loads;
    }
    private void Start()
    {
        ConnectionGraphPathCalculator.OnCircuitClose += LoadsTurningOnControl;
    }
    public static void AddLoad(Load load)
    {
        Debug.Log("ADDING" + load.name +"to load mangers");
        Loads.Add(load);
    }
    public static bool IsLoadConnectedToBattery(Load load)
    {
        int Point1ID = load.posativePoint.ID;
        int Point2ID = load.negativePoint.ID;
        var allPathes = ConnectionGraphPathCalculator.AllPathesOfBattery;
        foreach(var path in allPathes)
        {
            if (path.Contains(Point1ID) && path.Contains(Point2ID))
            {
                Debug.Log(load.name + " IS connected to battery");
                return true;
            }
                
        }
        return false;
    }
    public static void LoadsTurningOnControl()
    {
        Debug.Log("I know circuit close");
        foreach (Load load in Loads)
        {
            if (IsLoadConnectedToBattery(load))
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
