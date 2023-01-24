using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cutter : PointInteractiveTool
{

    void Start()
    {
        triggerClicked.action.started += RemoveTouchedPoint;
    }
    void RemoveTouchedPoint(InputAction.CallbackContext context)
    {
        Debug.Log("Deleting the point and calling this from cutter");
        if(TouchedPoint != null)
            GameManger.GraphManger.DisconnectPoint(TouchedPoint);
    }
}
