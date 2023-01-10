using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point :MonoBehaviour
{
    static int PointsCountID = 0;
    public static List<Point> Points = new List<Point>();
    public int ID { get; set; }
    
    public List<Point> ConnectedPoints;
    public Point PairPoint { get; set; }
    public Load ParentLoad { get ; set; }
    private void Awake()
    {
        ID = PointsCountID++;
        Debug.Log("Point created with ID: " + ID);
        gameObject.name = "Point " + ID;
        ConnectedPoints = new List<Point>();
        Points.Add(this);
    }
    void Start()
    {
        ConnectionGraphBuilder.addNewPointToGraph(this);
        if (ConnectionGraph.AdjacencyList.ContainsKey(PairPoint.ID))
        {
            ConnectionGraphBuilder.addNewConnectioBetween2NodesInGraph(this, PairPoint,ParentLoad.getResistance());
        }
    }

    public List<Point> GetConnectedPoints()
    {
        return ConnectedPoints;
    }

}
