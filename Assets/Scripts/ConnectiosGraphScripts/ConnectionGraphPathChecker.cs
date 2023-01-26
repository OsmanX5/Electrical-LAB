using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionGraphChecker : ConnectioGraphPathesProvider
{
    public  event Action OnCircuitClose;
    public event Action OnCircuitOpen;


    protected void CheckCircuit()
    {
        List<List<int>> AllPathesOfBattery = GetAllPathesOfBattery();
        if (AllPathesOfBattery.Count>0)
        {
            IsCircuitClosed = true;
            Debug.Log("Circuit closed" + AllPathesOfBattery.Count);
            foreach (var path in AllPathesOfBattery)
            {
                string s = "";
                foreach (var point in path)
                {
                    s += point.ToString()+" " ;
                }
                Debug.Log("Path : " + s);
            }
            OnCircuitClose?.Invoke();
        }
        else
        {
            if (IsCircuitClosed==true)
            {
                Debug.Log("Circuit opened");
                IsCircuitClosed = false;
                OnCircuitOpen?.Invoke();
            }
        }
    }
}
