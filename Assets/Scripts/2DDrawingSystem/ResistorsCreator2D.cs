using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResistorsCreator2D : ComponentsCreator2D
{
    // Start is called before the first frame update
    void Awake()
    {
        LoadsManger.OnAddNewLoad += Create2Dresistor;
    }
    public void Create2Dresistor(Load load)
    {
        base.Create2DComponent(load.gameObject);

    }
}
