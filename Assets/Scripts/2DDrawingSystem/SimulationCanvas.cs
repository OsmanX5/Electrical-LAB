using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationCanvas : MonoBehaviour
{
    public static Canvas canvas;
    public Canvas simulationCanvas;
    void Start()
    {
        canvas = simulationCanvas;
    }
}
