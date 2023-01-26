using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class PointsCreator2D : ComponentsCreator2D
{
    private void Awake()
    {
        GameManger.GraphManger.OnAddNewPoint += Create2Dpoint;
    }
    public void Create2Dpoint(Point point)
    {
        base.Create2DComponent(point.gameObject);

    }
}
