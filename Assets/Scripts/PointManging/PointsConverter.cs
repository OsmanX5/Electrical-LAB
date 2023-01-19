using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PointsConverter 
{
    public static Point ToPoint(int id)
        => PointsManger.GetPointByID(id);
    public static Point ToPoint(Transform transform) 
        => transform.GetComponent<Point>();
    public static Point ToPoint(GameObject obj) 
        => obj.GetComponent<Point>();
    
    public static int ToID(Point point) 
        => point.ID; 
    public static int ToID(Transform transform) 
        => ToPoint(transform).ID;
    public static int ToID(GameObject obj) 
        => ToPoint(obj).ID;
    
    
    public static Transform ToTransform(Point point) 
        => point.transform;
    public static Transform ToTransform(int id) 
        => ToTransform(ToPoint(id));
    
    public static Vector3 ToPoistion(Point point) 
        => point.transform.position;
    public static Vector3 ToPoistion(int id) 
        => ToTransform(id).position;
    public static Vector3 ToPoistion(Transform transform) 
        => transform.position;
    
    
    public static Point[] ToPoints(IEnumerable<int> ids) 
        => ids.Select(ToPoint).ToArray();
    public static Point[] ToPoints(IEnumerable<Transform> transforms) 
        => transforms.Select(ToPoint).ToArray();
    public static Point[] ToPoints(IEnumerable<GameObject> objects) 
        => objects.Select(ToPoint).ToArray();
    
    
    public static int[] ToIDs(IEnumerable<Point> points) 
        => points.Select(ToID).ToArray();
    public static int[] ToIDs(IEnumerable<Transform> transforms) 
        => transforms.Select(ToID).ToArray();
    public static int[] ToIDs(IEnumerable<GameObject> objects) 
        => objects.Select(ToID).ToArray();
    
    
    public static Transform[] ToTransforms(IEnumerable<Point> points) 
        => points.Select(ToTransform).ToArray();
    public static Transform[] ToTransforms(IEnumerable<int> ids) 
        => ids.Select(ToTransform).ToArray();
    
    
    public static Vector3[] ToPositions(IEnumerable<Point> points) 
        => points.Select(ToPoistion).ToArray();
    public static Vector3[] ToPositions(IEnumerable<int> ids) 
        => ids.Select(ToPoistion).ToArray();
    public static Vector3[] ToPositions(IEnumerable<Transform> transforms)
        => transforms.Select(ToPoistion).ToArray();

}
