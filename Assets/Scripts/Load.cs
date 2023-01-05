using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : MonoBehaviour,ILoad
{
    [SerializeField] float Resistor = 10f;
    [SerializeField] LoadType Type;
    ILoad loadBehovier;

    private void Start()
    {
        switch (Type)
        {
            case LoadType.Lamp: 
                loadBehovier = new Lamp();
                break;
            
            default: break;
        }
    }
    public void TurnOn()
    {
        loadBehovier.TurnOn();
    }
    public void TurnOff()
    {
        loadBehovier.TurnOff();
    }
}
