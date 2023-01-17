using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManger : MonoBehaviour
{
    public static Dictionary<Tuple<int, int>, Vector3[]> PointsOdPath = new Dictionary<Tuple<int, int>, Vector3[]> ();

    public static void SetPathPointsBetween(int a, int b, Vector3[] path)
    {
        PointsOdPath[new Tuple<int, int>(a, b)] = path;
        PointsOdPath[new Tuple<int, int>(b, a)] = path;
    }
    public static Vector3[] GetPathPointsBetween(int a, int b)
    {
        if (!PointsOdPath.ContainsKey(new Tuple<int, int>(a, b)))
        {
            return new Vector3[2] { PointsManger.GetPointByID(a).transform.position, PointsManger.GetPointByID(b).transform.position };
        }
        else
        {
            return  PointsOdPath[new Tuple<int, int>(a, b)];
        }
        
    }

}
