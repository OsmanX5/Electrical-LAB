using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ComponentCreator:  MonoBehaviour
{
    Transform creationTransform;

    public Transform CreationTransform { get => creationTransform; set => creationTransform = value; }

    public void CreateNewComponent(GameObject component) { 
        Debug.Log("Creating new component");
        GameObject newComponent = Instantiate(component, CreationTransform.position, Quaternion.identity);
    }
        
}
