using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionGraphPathCalculator : MonoBehaviour
{
    private void Start()
    {
        
    }
    public static bool IsPathExist(int startID, int endID)
    {
        Dictionary<int, List<ConnectionPoint>> graph = ConnectionGraph.AdjacencyList;
        bool[] visited = new bool[graph.Count];
        bool PathExist = false;
        void DFS(int startID)
        {
            if (startID == endID)
            {
                Debug.Log("Path Found");
                PathExist = true;
                return;
            }
            visited[startID] = true;
            foreach (var connectionPoint in graph[startID])
            {
                if (!visited[connectionPoint.point.ID])
                {
                    DFS(connectionPoint.point.ID);
                }
            }
        }
        return PathExist;
    }

}
