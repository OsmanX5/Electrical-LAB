using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.ComponentModel;

public class PointsConnector : MonoBehaviour
{
    public TMP_InputField inp1;
    public TMP_InputField inp2;
    int id1;
    int id2;
    private void Start()
    {
        inp1.text = "0";
        inp2.text = "1";
    }
    void Update()
    {
        id1 = int.Parse(inp1.text);
        id2 = int.Parse(inp2.text);
    }
    public void OnClickConnect()
    {
        ConnectNodes(id1, id2);
    }
    public static void ConnectNodes(int id1, int id2)
    {
        ConnectNodes(Point.Points[id1], Point.Points[id2]);
    }
    public static void ConnectNodes(Point a,Point b)
    {
        a.ConnectedPoints.Add(b);
        b.ConnectedPoints.Add(a);
        ConnectionGraphBuilder.addNewConnectioBetween2NodesInGraph(a, b, 0);
    }
}
