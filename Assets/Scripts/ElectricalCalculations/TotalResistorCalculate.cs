using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalResistorCalculate : MonoBehaviour
{
    public static float TotalResistor = 0;
    public void Calculate()
    {
        UpdateResistorGraphFromManger();
        CalculateTotalResistor();
    }
        
    public void UpdateResistorGraphFromManger()
    {
        GraphCalculator.graph = GameManger.GraphManger.Graph.UWGraph.Clone() as UndirectedWeightedGraph;
        GraphCalculator.startID = GameManger.GraphManger.StartID;
        GraphCalculator.endID = GameManger.GraphManger.EndID;
    }
    public bool ConnectNextSeries()
    {
        Debug.Log("Calc next Series");
        return ResistorsSerialConnect.CalculateNextSeries(); 
    }
    
    public void CalculateTotalResistor()
    {
        ResistorsSerialConnect.CalculateAllSeries();
        TotalResistor = GraphCalculator.GetTotalResistor();
    }

}
