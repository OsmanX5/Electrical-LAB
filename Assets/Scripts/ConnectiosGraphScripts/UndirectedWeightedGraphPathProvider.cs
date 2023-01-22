using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UndirectedWeightedGraphPathProvider : UndirectedWeightedGraphBuilder
{
    
    public bool IsPathExict(int a, int b)
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
    public List<List<int>> GetAllPaths(int start, int end)
    {
        List<List<int>> paths = new List<List<int>>();

        void DFS(int x, List<int> path)
        {
            path.Add(x);
            if (x == end)
            {
                foreach (var path1 in paths)
                {
                    if (path1.SequenceEqual(path)) return;
                }
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
    public List<string> GetAllPathesSTR(int a, int b)
    {
        List<List<int>> pathes = GetAllPaths(a, b);
        List<string> res = new List<string>();
        foreach (var path in pathes)
        {
            string str = "";
            foreach (var point in path)
                str += point.ToString() + " - ";
            res.Add(str);
        }
        return res;
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

}
