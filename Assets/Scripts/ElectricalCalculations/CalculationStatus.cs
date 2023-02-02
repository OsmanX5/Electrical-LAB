using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CalculationStatus : MonoBehaviour
{
    public TMP_Text statues;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        statues.text = ResistorsSerialConnect.graph.ToString();
    }
}
