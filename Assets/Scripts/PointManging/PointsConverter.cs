using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PointsConverter 
{
    public static Point ToPoint(int id)=> PointsManger.GetPointByID(id);
    public static Point ToPoint(Transform transform) => transform.GetComponent<Point>();
    public static Point ToPoint(GameObject obj) => obj.GetComponent<Point>();
    public static int ToID(Point point) => point.ID;
    public static int ToID(Transform transform) => ToPoint(transform).ID;
    public static int ToID(GameObject obj) => ToPoint(obj).ID;
    public static Transform ToTransform(Point point) => point.transform;
    public static Transform ToTransform(int id) => ToTransform(ToPoint(id));
    public static Point[] ToPoints(int[] ids) => ids.Select(ToPoint).ToArray();
    public static Point[] ToPoints(Transform[] transforms) => transforms.Select(ToPoint).ToArray();
    public static Point[] ToPoints(GameObject[] objects) => objects.Select(ToPoint).ToArray();
    public static int[] ToIDs(Point[] points) => points.Select(ToID).ToArray();
    public static int[] ToIDs(Transform[] transforms) => transforms.Select(ToID).ToArray();
    public static int[] ToIDs(GameObject[] objects) => objects.Select(ToID).ToArray();
    public static Transform[] ToTransforms(Point[] points) => points.Select(ToTransform).ToArray();
    public static Transform[] ToTransforms(int[] ids) => ids.Select(ToTransform).ToArray();

}
