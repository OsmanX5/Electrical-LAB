using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryCreator2D : ComponentsCreator2D
{
    public PowerSource powerSource;
    private void Start()
    {
        Create2DBattery(powerSource);
    }
    public void Create2DBattery(PowerSource powerSource)
    {
        base.Create2DComponent(powerSource.gameObject);

    }
}
