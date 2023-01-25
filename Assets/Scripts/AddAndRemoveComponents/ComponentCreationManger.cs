﻿using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ComponentCreationManger : MonoBehaviour
{
    CreationPlace creationPlace;
    ComponentsManger components;
    ComponentCreator creator;
    private void Start()
    {
        creator = this.AddComponent<ComponentCreator>();
        creator.CreationTransform = creationPlace.transform;
    }
    public void CreateNewComponent(string name)
    {
        if (creationPlace.IsPlaceIsEmpty())
        {
            GameObject prefab = components.GetComponent(name);
            creator.CreateNewComponent(prefab);
        }
    }
}
