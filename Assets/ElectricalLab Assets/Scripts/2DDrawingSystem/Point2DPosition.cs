using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Point2DPosition : Component2DPosition
{
    public Point PointRefrence;
    void Start()
    {
        PointRefrence = refrence.GetComponent<Point>();
        TMP_Text Point2DText = this.GetComponentInChildren<TMP_Text>();
        Point2DText.text = PointRefrence.ID.ToString();
    }
}
