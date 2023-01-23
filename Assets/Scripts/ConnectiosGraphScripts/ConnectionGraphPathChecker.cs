using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionGraphChecker : ConnectioGraphPathesProvider
{
    public  event Action OnCircuitClose;
    
    public List<string> allPathes;// For debug
    public  ConnectionGraphChecker()
    {
        OnGraphUpdated += CheckCircuit;
    }
    void CheckCircuit()
    {
        List<List<int>> AllPathesOfBattery = GetAllPathesOfBattery();
        if (AllPathesOfBattery.Count>0)
        {
            allPathes = Graph.GetAllPathesSTR(StartID, EndID);
            OnCircuitClose?.Invoke();
        }
        else
        {
        }
    }
}
