using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILoad : IElectricalComponent
{
    public  void TurnOn();
    public  void TurnOff();
}
