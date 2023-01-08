using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : MonoBehaviour,ILoad
{
    [SerializeField] float resistance = 10f;
    [SerializeField] LoadType loadType;
    ILoad loadBehovier;

    private void Start()
    {
        switch (loadType)
        {
            case LoadType.Lamp: 
                loadBehovier = new Lamp();
                break;
            case LoadType.Buzzer:
                loadBehovier = new Buzzer();
                break;

            default: break;
        }
    }
    public float getResistance()
    {
        return resistance;
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
