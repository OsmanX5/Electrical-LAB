using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentsCreator2D : MonoBehaviour
{
    public GameObject ComponentPrefab;
    public Canvas canvas;
    public void Create2DComponent(GameObject objRef)
    {
        GameObject temp = Instantiate(ComponentPrefab, canvas.transform);
        temp.GetComponent<Component2DPosition>().refrence = objRef;
        temp.GetComponent<Component2DPosition>().canvas = this.canvas;
        temp.name = objRef.name.ToString();

    }
}
