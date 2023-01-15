using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndirectedWeightedGraph 
{
    int n = 0;
    public Dictionary<int,List<Tuple<int, float>>> AdjacencyList;
    public UndirectedWeightedGraph()
    {
        AdjacencyList = new Dictionary<int, List<Tuple<int, float>>>();
    }

    public bool IsInGraph(int a)=> AdjacencyList.ContainsKey(a);

    public List<Tuple<int,float>> GetPointConnections(int a)=>AdjacencyList[a];

    public void addPoint(int a)
    {
        AdjacencyList[a] = new List<Tuple<int, float>>();
        n += 1;
    }
    public void AddConnection(int a,int b,float w)
    {
        if (!IsInGraph(a)) addPoint(a);
        if (!IsInGraph(b)) addPoint(b);
        AdjacencyList[a].Add(new Tuple<int, float>(b, w));
        AdjacencyList[b].Add(new Tuple<int, float>(a, w));
    }
    public bool IsPathExict(int a,int b)
    {
        bool pathFound = false;
        bool[] visited = new bool[n];
        void DFS(int x)
        {
            if (x == b)
                pathFound = true;
            visited[x] = true;
            foreach (var next in AdjacencyList[x])
            {
                int nextID = next.Item1;
                if (visited[nextID]) continue;
                DFS(nextID);
            }
        }
        DFS(a);
        
        return pathFound;
    }

}
