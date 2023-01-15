using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PointHovering : MonoBehaviour
{
    public GameObject CANVAS;
    public TMP_Text Num;
    private void Start()
    {
        CANVAS.SetActive(false);
    }
    private void OnMouseOver()
    {
        CANVAS.SetActive(true);
        Num.text = this.name;
    }
    private void OnMouseDown()
    {
        if(PointsConnector.firstClick == true)
        {
            PointsConnector.firstClick = false;
            PointsConnector.firstPoint = this.GetComponent<Point>();
        }
        else if(PointsConnector.firstClick == false)
        {
            PointsConnector.firstClick = true;
            PointsConnector.ConnectNodes(PointsConnector.firstPoint, this.GetComponent<Point>());
        }
    }
    private void OnMouseExit()
    {
        CANVAS.SetActive(false);
    }
}
