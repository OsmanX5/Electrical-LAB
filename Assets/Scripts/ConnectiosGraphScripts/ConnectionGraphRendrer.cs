using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ConnectionGraphRendrer : MonoBehaviour
{
    public GameObject LRPrefab;
    [SerializeField] List<LineRenderer> lineRenderers = new List<LineRenderer>();
    private void Start()
    {
        ConnectionGraphBuilder.OnAddNewPoint += UpdateLineRendrers;
        ConnectionGraphBuilder.OnConnectTwoNodes += UpdateLineRendrers;
    }
    private int NumberOfNeededLR() => ConnectionGraph.DisJointSet.JointsCount;

    private void CreateLineRenderes(int n)
    {
        lineRenderers = new List<LineRenderer>();
        for(int i =0; i < n; i++)
        {
            LineRenderer  temp = Instantiate(LRPrefab,this.transform).GetComponent<LineRenderer>();
            lineRenderers.Add(temp);
        }
    }
    private void DeletOldLineRenderes()
    {
        foreach(var line in lineRenderers)
        {
            Destroy(line.gameObject);
        }
    }
    private void UpdateLineRendrers()
    {
        DeletOldLineRenderes();
        CreateLineRenderes(NumberOfNeededLR());
        DrawNewLineRendrers();
    }
    private void DrawNewLineRendrers()
    {
        var joints = ConnectionGraph.DisJointSet.Joints;
        int index = 0;
        foreach(var joint in joints)
        {
            int[] pointsId = joint.Value.ToArray();
            Point[] points = (from pointId in pointsId select PointsManger.GetPointWithID(pointId)).ToArray();
            drawLines(lineRenderers[index], points);
            index += 1;
        }
    }
    private void drawLines(LineRenderer LR, Point[] points)
    {
        Transform[] pointsTransforms = (from point in points select point.transform).ToArray();
        drawLines(LR, pointsTransforms);
    }
    private void drawLines(LineRenderer LR, Transform[] points)
    {
        LR.positionCount = points.Length;
        for (int i = 0; i < points.Length; i++)
        {
            LR.SetPosition(i, points[i].position);
        }
    }

}
