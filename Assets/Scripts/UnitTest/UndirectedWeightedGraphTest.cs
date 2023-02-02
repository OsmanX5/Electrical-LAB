using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndirectedWeightedGraphTest : MonoBehaviour
{
    public ElectricalGraph graph = new ElectricalGraph();
    List<int> Nodes = new List<int>() {0,1,20,30,4};

    private void Start()
    {
        PrintAdjacencyList();
        addNodeTest();
        PrintAdjacencyList();
        Connect2NodesTest();
        PrintAdjacencyList();
        ClearPointTest();
        PrintAdjacencyList();
    }
    void addNodeTest()
    {
        Debug.Log("######Test adding new nodes#######");
        Debug.Log("Test to adding nodes");
        for (int i = 0; i < Nodes.Count; i++)
        {
            Debug.Log(Nodes[i]);
            graph.UWGraph.AddNewPoint(Nodes[i]);
        }
        Debug.Log("#####Adding New node test end####");
    }
    
    void Connect2NodesTest()
    {
        Debug.Log("######Connect2NodesTest#######");
        Debug.Log("Test for connecting");
        List<Tuple<int,int,float>> connections = new(){new(0, 1, 10) ,
            new(0, 2, 20),new(1, 0, 30),new(1, 4, 0),new(20, 30, 5) };
        foreach(var connection in connections)
        {
            Debug.Log($"connecting {connection.Item1} <=={connection.Item3} ===> {connection.Item2}");
            graph.UWGraph.AddConnection(connection.Item1, connection.Item2, connection.Item3);
        }
        Debug.Log("#####Connect2NodesTest####");
    }

    void RemovePointTest()
    {
        Debug.Log("######RemovePoint test#######");
        Debug.Log("Test for Removing");
        foreach (var i in new List<int> { 1,30})
        {
            Debug.Log(i);
            graph.UWGraph.RemovePoint(i);
        }
        Debug.Log("#####End of RemovePoint####");
    }
    void ClearPointTest()
    {
        Debug.Log("######ClearPointTest test#######");
        Debug.Log("Test for clearing");
        foreach (var i in new List<int> { 1 })
        {
            Debug.Log(i);
            graph.UWGraph.ClearPoint(i);
        }
        Debug.Log("#####End of ClearPointTest####");
    }



    void PrintAdjacencyList()
    {
        print("current adjacecy List");
        Debug.Log(graph.ToString());
    }




}
