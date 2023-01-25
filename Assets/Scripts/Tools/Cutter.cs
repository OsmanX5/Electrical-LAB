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
            TouchedPoint = null;
        }
          
    }

    private void RemoveComponentPoint()
    {
        ComponentPoint componentPoint = TouchedPoint as ComponentPoint;
        RemoveConnectedNodes(componentPoint);
        GameManger.GraphManger.ClearPoint(componentPoint);
        if ( componentPoint.ElectricalComponent is Load)
        {
            Load load = componentPoint.ElectricalComponent as Load;
            PointsConnector.ConnectPoints(componentPoint, componentPoint.PairPoint, load.Resistance);
        }
    }

    void RemoveNodePoint()
    {
        NodePoint nodePoint = TouchedPoint as NodePoint;
        RemoveConnectedNodes(nodePoint);
        TouchedPoint.Delet();
    }
    void RemoveConnectedNodes(Point ToDeletPoint)
    {
        List<NodePoint> ToDelet = GameManger.GraphManger.GetConnectedNodePoints(ToDeletPoint);
        foreach (NodePoint point in ToDelet)
        {
            GameManger.GraphManger.RemovePoint(point);

        }
        foreach (NodePoint point in ToDelet)
        {
            point.Delet();
        }
    }

}
