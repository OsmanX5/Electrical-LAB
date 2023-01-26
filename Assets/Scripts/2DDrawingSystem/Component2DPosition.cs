using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Component2DPosition : MonoBehaviour
{
    public GameObject refrence;
    public Canvas canvas;
    void Start()
    {
       // TMP_Text Point2DText = this.GetComponentInChildren<TMP_Text>();
       // Point2DText.text = "";
    }

    void FixedUpdate()
    {
        UpdateComponentPosition();
    }
    protected virtual void UpdateComponentPosition()
    {
        Vector3 center =refrence.transform.position;
        Vector3 newPos = Convert3Dto2DPositions.Convert3Dto2D(center);
        newPos = new Vector3(newPos.x, newPos.y, canvas.transform.position.z);
        transform.position = newPos;
        transform.rotation = Quaternion.Euler(0, 0, refrence.transform.rotation.eulerAngles.y);
    }

}
