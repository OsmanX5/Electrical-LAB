using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class PointsCreator2D : MonoBehaviour
{
    [SerializeField] GameObject pointPrefab;
    public Canvas canvas;
    Convert3Dto2DPositions converter;

    private void Start()
    {
        GameManger.GraphManger.OnAddNewPoint += Create2Dpoint;
        converter = this.GetComponent<Convert3Dto2DPositions>();
    }
    public void Create2Dpoint(Point point)
    {
        GameObject temp = Instantiate(pointPrefab, canvas.transform);
        temp.GetComponent<Point2DPosition>().refrence = point;
        temp.name = point.ID.ToString();

    }
}
