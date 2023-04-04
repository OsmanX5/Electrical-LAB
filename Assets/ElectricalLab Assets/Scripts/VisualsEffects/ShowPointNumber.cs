using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowPointNumber : MonoBehaviour
{
    public TMP_Text text;
    void Update()
    {
        text.text = this.GetComponent<Point>().ID.ToString();
    }
}
