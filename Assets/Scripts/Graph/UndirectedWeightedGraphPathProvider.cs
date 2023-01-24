using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UndirectedWeightedGraphPathProvider : UndirectedWeightedGraphBuilder
{
    
    public bool IsPathExict(int a, int b)
    {
        return GetPath(a, b).Count > 0;
    }
    public List<int> GetPath(int a, int b)
    {
        var pathes = GetAllPaths(a, b);
        if (pathes.Count == 0) return new List<int>();
        return pathes[0];
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
            foreach (Edge next in AdjacencyList[x])
            {
                int nextID = next.NextPoint;
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
   

}