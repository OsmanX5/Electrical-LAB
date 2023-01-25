using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class Point2DPosition : MonoBehaviour
{
    public Point refrence; 
    void Start()
    {
        TMP_Text Point2DText = this.GetComponentInChildren<TMP_Text>();
        Point2DText.text = refrence.ID.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 positions = Convert3Dto2DPositions.Convert3Dto2D(refrence.transform.position);
        transform.position = new Vector3(positions.x, positions.y, transform.position.z);
    }
}
