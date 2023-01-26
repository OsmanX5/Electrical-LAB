using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ComponentCreationManger : MonoBehaviour
{
    public CreationPlace creationPlace;
    ComponentsManger components;
    ComponentCreator creator;
    private void Start()
    {
        if (creationPlace == null) 
            creationPlace = GetComponentInChildren<CreationPlace>();
        components = this.GetComponent<ComponentsManger>();
        creator = this.AddComponent<ComponentCreator>();
        creator.CreationTransform = creationPlace.transform;
    }
    public void CreateNewComponent(string name)
    {
        if (creationPlace.IsPlaceIsEmpty())
        {
            GameObject prefab = components.GetComponentByName(name);
            creator.CreateNewComponent(prefab);
        }
    }
}
