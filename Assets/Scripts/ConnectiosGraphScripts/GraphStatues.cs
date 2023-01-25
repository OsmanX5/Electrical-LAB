using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
public class GraphStatues : MonoBehaviour
{
    public TMP_Text text;
    void Update()
    {
        string s = "";
        s = GameManger.GraphManger.Graph.ToString();
        s += GameManger.GraphManger.GetPathesOfBatterySTR();
        text.text = s;

    }

}
