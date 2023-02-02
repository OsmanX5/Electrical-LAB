using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalResistorCalculate : MonoBehaviour
{
    
    public void Calculate()
    {
        UpdateResistorGraphFromManger();
        ResistorsSerialConnect.CalculateNextSeries();
    }
    public void UpdateResistorGraphFromManger()
    {
        ResistorsSerialConnect.graph = GameManger.GraphManger.Graph.UWGraph.Clone() as UndirectedWeightedGraph;
        ResistorsSerialConnect.startID = GameManger.GraphManger.StartID;
        ResistorsSerialConnect.endID = GameManger.GraphManger.EndID;
    }

}
