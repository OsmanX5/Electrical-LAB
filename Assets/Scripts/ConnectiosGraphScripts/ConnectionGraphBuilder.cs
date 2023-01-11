using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionGraphBuilder : MonoBehaviour
{
    public static void addNewPointToGraph(Point newPoint)
    {
        Debug.Log("Adding new point to graph point ID : "+ newPoint.ID);
        foreach ( var item in ConnectionGraph.AdjacencyList)
        {
            if (item.Key == newPoint.ID)
                {
                    Debug.Log("Point with ID: " + newPoint.ID + " already exists in graph");
                    return;
                }
        }
        ConnectionGraph.AdjacencyList.Add(newPoint.ID,new List<ConnectionPoint>());
        ConnectionGraph.DisJointSet.AddPoint(newPoint.ID);
        Debug.Log("POINT WITH ID : " + newPoint.ID + " Added to graph");
        ConnectionGraph.nodesCount += 1;
    }
    public static void AddPointToIDConnections(int PointId,Point PointToAdd,float resistance =0 )
    {
        if (PointId == PointToAdd.ID)
        {
            Debug.Log("Cannot connect point with itself");
            return;
        }
        Debug.Log("try Adding point with ID" + PointToAdd.ID + "to ID" + PointId);
        foreach (var connection in ConnectionGraph.AdjacencyList[PointId]){
            if (connection.point.ID == PointToAdd.ID)
            {
                Debug.Log("Point with ID: " + PointToAdd.ID + " already connected here");
                return;
            }
        }
        ConnectionGraph.AdjacencyList[PointId].Add(new ConnectionPoint(PointToAdd,resistance));
        Debug.Log("Successfully  Added point with ID" + PointToAdd.ID + "to ID" + PointId);
    }
    public static void addNewConnectioBetween2NodesInGraph(Point a,Point b)
    {
        if (ConnectionGraph.AdjacencyList.ContainsKey(a.ID) == false)
            addNewPointToGraph(a);
        if (ConnectionGraph.AdjacencyList.ContainsKey(b.ID) == false)
            addNewPointToGraph(b);
        if (a == b.PairPoint)
        {
            Debug.Log("Cannot connect point with its pair");
            return;
        }
        if (ConnectionGraph.DisJointSet.IsConnected(a.ID, b.ID))
        {
            Debug.Log("Points are already connected");
            return;
        }
        AddPointToIDConnections(a.ID, b);
        AddPointToIDConnections(b.ID, a);
        ConnectionGraph.DisJointSet.Union(a.ID, b.ID);
    }
    public static void ConnectToThePair(Point a,float resistance)
    {
        AddPointToIDConnections(a.ID, a.PairPoint,resistance);
        AddPointToIDConnections(a.PairPoint.ID, a,resistance);
    }
    public static void RemovePointFromGraph(Point point)
    {
        if(ConnectionGraph.AdjacencyList.ContainsKey(point.ID) == false)
        {
            Debug.Log("no point like this here when try to delet");
            return;
        }
        ConnectionGraph.AdjacencyList.Remove(point.ID);
    }


}
