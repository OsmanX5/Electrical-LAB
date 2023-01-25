using System;
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
                RemoveNodePoint();
            }
            else if(TouchedPoint is ComponentPoint)
            {
                RemoveComponentPoint();
            }
            TouchedPoint.Delet();
            TouchedPoint = null;
        }
          
    }

    private void RemoveComponentPoint()
    {
        ComponentPoint componentPoint = TouchedPoint as ComponentPoint;
        GameManger.GraphManger.ClearPoint(componentPoint);
        if ( componentPoint.ElectricalComponent is Load)
        {
            Load load = componentPoint.ElectricalComponent as Load;
            PointsConnector.ConnectPoints(componentPoint, componentPoint.PairPoint, load.Resistance);
        }
    }

    void RemoveNodePoint()
    {
        GameManger.GraphManger.RemovePoint(TouchedPoint);
    }
}
