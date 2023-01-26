using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentsCreator2D : MonoBehaviour
{
    public GameObject ComponentPrefab;
    public void Create2DComponent(GameObject objRef)
    {
        Canvas canvas = SimulationCanvas.canvas;
        GameObject temp = Instantiate(ComponentPrefab, canvas.transform);
        temp.GetComponent<Component2DPosition>().refrence = objRef;
        temp.name = objRef.name.ToString();

    }
}
