using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionGraphPathCalculator : MonoBehaviour
{
    public static event Action OnCircuitClose;
    public static List<List<int>> AllPathesOfBattery = new List<List<int>>();
    public List<string> allPathes;
    private void Start()
    {
        ConnectionGraphBuilder.OnGraphUpdated += CircuitCloseCheck;
    }
    void CircuitCloseCheck()
    {
        Debug.Log("calculating all pathes of battery");
        AllPathesOfBattery = ConnectionGraph.graph.GetAllPaths(ConnectionGraph.StartID, ConnectionGraph.EndID);
        Debug.Log("Found" + AllPathesOfBattery.Count + "pathes");
        if (AllPathesOfBattery.Count>0)
        {
            allPathes = ConnectionGraph.graph.GetAllPathesSTR(ConnectionGraph.StartID, ConnectionGraph.EndID);
            Debug.Log("Circuit closed");
            OnCircuitClose?.Invoke();
        }
        else
        {
            Debug.Log("Circuit still open");
        }
    }
}
