using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class RemoveTest : MonoBehaviour
{
    public InputActionReference RemoveAction;
    // Update is called once per frame
    void Start()
    {
        RemoveAction.action.started += RemovePoint;
    }
    void RemovePoint(InputAction.CallbackContext context)
    {
        Debug.Log("Deleting the point");
        ConnectionGraph.builder.DisconnectPoint(PointsManger.GetPointByID(3));
    }
}
