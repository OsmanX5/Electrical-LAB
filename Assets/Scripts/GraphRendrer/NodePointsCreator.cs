using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodePointsCreator : MonoBehaviour
{
    [SerializeField] static GameObject PointPrefab;

    public static List<NodePoint> BuildePoints(List<Vector3> pointsPos)
    {
        List<NodePoint> result = new List<NodePoint>();
        for (int i = 0; i < pointsPos.Count; i++)
        {
            NodePoint newPoint = Instantiate(PointPrefab, pointsPos[i], Quaternion.identity).GetComponent<NodePoint>();
            newPoint.Initlize();
            result.Add(newPoint);
        }
        return result;
    }
}
