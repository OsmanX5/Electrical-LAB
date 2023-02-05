using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResistorCalculator 
{
    public static float TotalResistor = 0;
    
    
    public float GetTotalResistor(TargtedUWGraph graph)
    {
        ResistorsSerialConnect.CalculateAllSeries();
        TotalResistor = GraphCalculator.GetTotalResistor();
    }

}
