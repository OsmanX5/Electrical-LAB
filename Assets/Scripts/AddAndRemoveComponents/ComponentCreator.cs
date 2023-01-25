using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ComponentCreator : MonoBehaviour
{
    public Transform CreationTransform;
    public List<GameObject> Components;
    CreationPlace creationPlaceControl;
    private void Start()
    {
        creationPlaceControl = CreationTransform.GetComponent<CreationPlace>();
    }

    public void OnClickCreateLamp()
    {
        if(IsPlaceIsEmpty())
        CreateNewComponent(Components[0]);
    }
    public bool IsPlaceIsEmpty()=> creationPlaceControl.OnPlaceObjects.Count == 0;
    public void CreateNewComponent(GameObject component) { 
        Debug.Log("Creating new component");
        GameObject newComponent = Instantiate(component, CreationTransform.position, Quaternion.identity);
    }
        
}
