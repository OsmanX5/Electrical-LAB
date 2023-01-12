using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ConnectionGraphRendrer : MonoBehaviour
{
    public GameObject LRPrefab;
    [SerializeField] Dictionary<int , LineRenderer> lineRenderers = new Dictionary<int, LineRenderer>();
    private void Awake()
    {
        ConnectionGraphBuilder.OnAddNewPoint += AddLineRendrer;
        ConnectionGraphBuilder.OnConnectTwoNodes += ConnectToLinePoints;
    }
    private int NumberOfNeededLR() => ConnectionGraph.DisJointSet.JointsCount;

    private void AddLineRendrer(Point point) => AddLineRendrer(point.ID);
    private void AddLineRendrer(int id)
    {
        LineRenderer temp = Instantiate(LRPrefab, this.transform).GetComponent<LineRenderer>();
        temp.name = "Line Rendrer to joint " +  id.ToString();
        lineRenderers[id] = temp;
    }
    
    private void DeletLineRendrer(int id)
    {
        Destroy(lineRenderers[id].gameObject);
        lineRenderers.Remove(id);
    }

    private void ConnectToLinePoints(Point a, Point b) => ConnectToLineRendrers(a.ID, b.ID);
    private void ConnectToLineRendrers(int id1, int id2)
    {
        int deletedID;
        int notDeletedID;
        if (ConnectionGraph.DisJointSet.GetJointsHead().Contains(id1)) {
            deletedID = id2;
            notDeletedID = id1;
        }
        else
        {
            deletedID = id1;
            notDeletedID = id2;
        }
        DeletLineRendrer(deletedID);
        LineRenderer Line = lineRenderers[notDeletedID];
        drawLines(Line,PointsManger.GetConnectedPointsToID(notDeletedID));
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
