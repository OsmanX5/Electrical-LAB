using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManger : MonoBehaviour
{
    public static Dictionary<Tuple<int, int>, Vector3[]> Pathes = new Dictionary<Tuple<int, int>, Vector3[]> ();

    public static void SetPathBetween(int a, int b, Vector3[] path)
    {
        Pathes[new Tuple<int, int>(a, b)] = path;
    }
    public static Vector3[] GetPathBetween(int a, int b)
    {
        return Pathes[new Tuple<int, int>(a,b)];
    }

}
