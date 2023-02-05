using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteGraphCalculator 
{
    TargtedUWGraph graph;
    public void UpdateGraphFromGameManger()
    {
        UndirectedWeightedGraph graphClone = GameManger.GraphManger.Graph.UWGraph.Clone() as UndirectedWeightedGraph;
        int start = GameManger.GraphManger.StartID;
        int end = GameManger.GraphManger.EndID;
        graph = new TargtedUWGraph(graphClone, start, end);
    }
    public float GetTotalResistor()
    {
        Debug.Log("calculating total Resistor");
        return 0;
    }
    public float GetTotalCurrent()
    {
        Debug.Log("calculating total Current");

        return 0;
    }
}
