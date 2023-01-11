using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionEventsHandler : MonoBehaviour
{
    public static event Action<Point> OnPointCreated;

    public static event Action<Point> OnPointConnected;
}
