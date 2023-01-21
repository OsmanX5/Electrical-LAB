using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionGraphChecker : ConnectionGraph
{
    public  event Action OnCircuitClose;
    
    public List<string> allPathes;// For debug
    public  ConnectionGraphChecker()
    {
        builder.OnGraphUpdated += CheckCircuitClose;
    }
    void CheckCircuitClose()
    {
        List<List<int>> AllPathesOfBattery = pathesProvider.GetAllPathesOfBattery();
        if (AllPathesOfBattery.Count>0)
        {
            allPathes = graph.GetAllPathesSTR(StartID, EndID);
            OnCircuitClose?.Invoke();
        }
        else
        {
        }
    }
}
