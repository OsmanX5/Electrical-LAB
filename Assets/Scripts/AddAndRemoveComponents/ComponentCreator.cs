using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ComponentCreator : MonoBehaviour
{
    public Transform CreationPlace;
    public List<GameObject> Components;
    
    public void OnClickCreateLamp()
    {
        CreateNewComponent(Components[0]);
    }
    public void CreateNewComponent(GameObject component) { 
        Debug.Log("Creating new component");
        GameObject newComponent = Instantiate(component, CreationPlace.position, Quaternion.identity);
    }
        
}
