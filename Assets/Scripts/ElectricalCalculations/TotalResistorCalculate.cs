using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalResistorCalculate : MonoBehaviour
{
    
    public void Calculate()
    {
        ResistorsSerialConnect.graph = GameManger.GraphManger.Graph.Clone() as ElectricalGraph;
        List<Point> BatteryPath = GameManger.GraphManger.GetAllPathesOfBattery()[0];
        for(int i=1;i< BatteryPath.Count - 2; i++)
        {
            ComponentPoint CurrentPoint = BatteryPath[i] as ComponentPoint;
            ComponentPoint NextPoint = BatteryPath[i + 1] as ComponentPoint;
            Debug.Log("in list : " + CurrentPoint.ID + " " + NextPoint.ID);
            if (ResistorsSerialConnect.IsSerialConnected(CurrentPoint, NextPoint))
            {
                ResistorsSerialConnect.Connect(CurrentPoint, NextPoint);
            }
        }
        Debug.Log(ResistorsSerialConnect.graph.ToString());
    }
}
