using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class ConnectionGraph : MonoBehaviour
{
    public static ElectricalGraph graph;
    public static DisJointSet DisJointSet;
    public static int StartID;
    public static int EndID;
    private void Awake()
    {
        graph = new ElectricalGraph();
        DisJointSet = new DisJointSet(0);
        this.AddComponent<ConnectionGraphBuilder>();
        this.AddComponent<ConnectionGraphPathCalculator>();
    }
    private void FixedUpdate()
    {
    }


    public static string GetAdjacencyListText()
    {
        string adjacencyListSTR = "";
        foreach (var item in graph.AdjacencyList)
        {
            adjacencyListSTR += item.Key + " : [";
            foreach (var connectionPoint in item.Value)
            {
                adjacencyListSTR += $" ({connectionPoint.Item1} , {connectionPoint.Item2} ) ";
            }
            adjacencyListSTR += " ] \n";
        }
        adjacencyListSTR += "Start Id = " + StartID +"\n";
        adjacencyListSTR += "End ID = " + EndID + "\n";
        return adjacencyListSTR;
    }

    public static bool IsInGraph(Point point) => IsInGraph(point.ID);
    public static bool IsInGraph(int ID)=> graph.AdjacencyList.ContainsKey(ID);
    
}
