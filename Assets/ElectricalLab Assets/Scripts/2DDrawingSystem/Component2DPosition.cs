using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Component2DPosition : MonoBehaviour
{
    public GameObject refrence;
    public Vector3 offset;
    void FixedUpdate()
    {
        UpdateComponentPosition();
    }
    protected virtual void UpdateComponentPosition()
    {
        Vector3 center =refrence.transform.position;
        Vector3 newPos = Convert3Dto2DPositions.Convert3Dto2D(center);
        newPos = newPos + offset;
        transform.position = newPos;
        transform.rotation = Quaternion.Euler(0, 0, -refrence.transform.rotation.eulerAngles.y);
    }

}
