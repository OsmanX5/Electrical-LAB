using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tool : MonoBehaviour
{

    public InputActionReference triggerClicked;
    public Point TouchedPoint;
    public bool Holding = false;

    public void StartHolding() => Holding = true;
    public void relese() => Holding = false;
   

}
