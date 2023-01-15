using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionGraphPathCalculator : MonoBehaviour
{
    public static event Action OnCircuitClose;

    private void Start()
    {
        ConnectionGraphBuilder.OnGraphUpdated += CircuitCloseCheck;
    }

    void CircuitCloseCheck()
    {
        if (ConnectionGraph.graph.IsPathExict(ConnectionGraph.StartID, ConnectionGraph.EndID))
        {
            Debug.Log("Circuit closed");
            OnCircuitClose?.Invoke();
        }
        else
        {
            Debug.Log("Circuit still open");
        }
    }
}
