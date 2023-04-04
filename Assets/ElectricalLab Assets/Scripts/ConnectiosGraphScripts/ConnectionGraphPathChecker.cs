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
        List<List<Point>> AllPathesOfBattery = GetAllPathesOfBattery();
        if (AllPathesOfBattery.Count>0)
        {
            IsCircuitClosed = true;
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
