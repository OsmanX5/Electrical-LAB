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
        if(TouchedPoint != null)
        {
            if(TouchedPoint is NodePoint)
            {
                GameManger.GraphManger.RemovePoint(TouchedPoint);
                TouchedPoint.Delet();
                TouchedPoint = null;
            }
        }
          
    }
}
