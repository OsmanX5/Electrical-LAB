using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Resistor2Dposition : Component2DPosition
{
    public Load refLoad; 
    void Start()
    {
        refLoad = refrence.GetComponent<Load>();
        TMP_Text Resistor2DText = this.GetComponentInChildren<TMP_Text>();
        Resistor2DText.text = refLoad.Resistance.ToString() + "K";
    }

}
