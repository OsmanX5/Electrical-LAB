using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cutter :Tool
{

    void Start()
    {
        triggerClicked.action.started += RemovePoint;
    }
    void RemovePoint(InputAction.CallbackContext context)
    {
        Debug.Log("Deleting the point");
        if(TouchedPoint != null)
        ConnectionGraph.builder.DisconnectPoint(TouchedPoint);
    }
}
