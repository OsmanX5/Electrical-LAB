using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ComponentsManger : MonoBehaviour
{
    public List<Component> Components = new List<Component>();
    public GameObject GetComponent(string name)
    {
        foreach (var component in Components)
        {
            if (component.Name == name)
                return component.CompObject;
        }
        return null;
    }
}