using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CalculationStatus : MonoBehaviour
{
    public TMP_Text statues;
    public TMP_Text totalResistor;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        statues.text = GraphCalculator.graph.ToString();
        totalResistor.text = "Total Resistor: " + ResistorCalculator.TotalResistor;
    }
}
