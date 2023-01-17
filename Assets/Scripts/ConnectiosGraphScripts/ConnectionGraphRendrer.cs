using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ConnectionGraphRendrer : MonoBehaviour
{
    public GameObject LRPrefab;
    //[SerializeField] Dictionary<int , LineRenderer> lineRenderers = new Dictionary<int, LineRenderer>();
    [SerializeField] List<LineRenderer> lineRenderers = new List<LineRenderer>();

    private void Awake()
    {
        //ConnectionGraphBuilder.OnAddNewPoint += AddLineRendrer;
        Wiere.OnConnectionWiereingEnd += WirerConnectionRender;
    }

    
    private void DeletLineRendrer(int id)
    {
        Destroy(lineRenderers[id].gameObject);
        lineRenderers.RemoveAt(id);
    }
    private void WirerConnectionRender(LineRenderer lr)
    {
        LineRenderer temp = Instantiate(LRPrefab, this.transform).GetComponent<LineRenderer>();
        temp.name = lineRenderers.Count().ToString();
        temp.positionCount = lr.positionCount;
        for (int i = 0; i < lr.positionCount; i++) temp.SetPosition(i, lr.GetPosition(i));
        lineRenderers.Add(temp);        
    }
    
    /*
    private int NumberOfNeededLR() => ConnectionGraph.DisJointSet.JointsCount;

    private void AddLineRendrer(Point point) => AddLineRendrer(point.ID);
    private void ConnectToLinePoints(Point a, Point b) => ConnectToLineRendrers(a.ID, b.ID);
    private void ConnectToLineRendrers(int id1, int id2)
    {
        int id1Head = ConnectionGraph.DisJointSet.Find(id1);
        int id2Head = ConnectionGraph.DisJointSet.Find(id2);
        foreach (int joint in ConnectionGraph.DisJointSet.GetJointPoints(id1Head))
        {
            if (lineRenderers.ContainsKey(joint) && joint != id1Head)
                DeletLineRendrer(joint);
        }
        
        LineRenderer Line = lineRenderers[id1Head];
        drawLines(Line,PointsManger.GetConnectedPointsToID(id1Head));
    }
    private void drawLines(LineRenderer LR, Point[] points)
    {
        Transform[] pointsTransforms = (from point in points select point.transform).ToArray();
        drawLines(LR, pointsTransforms);
    }
    private void drawLines(LineRenderer LR, Transform[] points)
    {
        WireCalculator.SetWireStright(LR, points);
    }
    */
}
