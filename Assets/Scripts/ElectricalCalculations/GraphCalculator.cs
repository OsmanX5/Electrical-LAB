using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphCalculator 
{
    public static UndirectedWeightedGraph graph = new();
    public static int startID = 0;
    public static int endID = 1;
    static List<float> resistorsValues = new();

    public static void calculateResistorsValues()
    {
        resistorsValues.Clear();
        List<int> path = graph.GetPath(startID, endID);
        for (int i = 0; i < path.Count - 1; i++)
        {
            resistorsValues.Add(graph.WeightBetween(path[i], path[i + 1]));
        }
    }
    public static float GetTotalResistor() {
        calculateResistorsValues();
        float total = 0;
        foreach (float resistor in resistorsValues)
        {
            total += resistor;
        }
        return total;
    }
        
}
