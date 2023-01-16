using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        
        List<Tuple<int, float>> aConnections = AdjacencyList[a];
        List<Tuple<int, float>> bConnections = AdjacencyList[b];
        AdjacencyList[a].Add(new Tuple<int, float>(b, w));
        AdjacencyList[b].Add(new Tuple<int, float>(a, w));
    }
    public bool IsInList(List<Tuple<int, float>> list, Tuple<int, float> a)
    {
        foreach (var point in list)
        {
            if (point.Item1 == a.Item1) return true;
        }
        return false;
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

    public List<int> GetPath(int a, int b)
    {
        List<int> path = new List<int>();
        bool[] visited = new bool[n];
        void DFS(int x)
        {
            if (x == b)
            {
                path.Add(x);
                return;
            }
            visited[x] = true;
            foreach (var next in AdjacencyList[x])
            {
                int nextID = next.Item1;
                if (visited[nextID]) continue;
                DFS(nextID);
                if (path.Count > 0)
                {
                    path.Add(x);
                    return;
                }
            }
        }
        DFS(a);
        path.Reverse();
        return path;
    }

    public List<List<int>> GetAllPaths(int start, int end)
    {
        List<List<int>> paths = new List<List<int>>();

        void DFS(int x, List<int> path)
        {
            path.Add(x);
            if (x == end)
            {
                paths.Add(path);
                return;
            }
            foreach (var next in AdjacencyList[x])
            {
                int nextID = next.Item1;
                if (path.Contains(nextID)) continue;
                DFS(nextID, new List<int>(path));
            }
        }
        DFS(start, new List<int>());

        return paths;
    }

    public List<string> GetAllPathesSTR(int a,int b)
    {
        List<List<int>> pathes = GetAllPaths(a, b);
        List<string> res = new List<string>();
        foreach(var path in pathes)
        {
            string str = "";
            foreach (var point in path)
                str += point.ToString() + " - ";
            res.Add(str);
        }
        return res;
    }
}
