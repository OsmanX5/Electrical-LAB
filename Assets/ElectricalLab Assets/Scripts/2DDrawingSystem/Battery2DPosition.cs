using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Battery2DPosition : Component2DPosition
{
    public PowerSource refBat;
    void Start()
    {
        refBat = refrence.GetComponent<PowerSource>();
        TMP_Text Resistor2DText = this.GetComponentInChildren<TMP_Text>();
        Resistor2DText.text = refBat.voltage.ToString() + " V";
    }
}
