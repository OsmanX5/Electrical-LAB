using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargtedUWGraph 
{
    UndirectedWeightedGraph _graph;
    int _Start;
    int _End;
    public TargtedUWGraph(UndirectedWeightedGraph graph, int Start, int End)
    {
        Graph = graph;
        this.Start = Start;
        this.End = End;
    }

    public UndirectedWeightedGraph Graph { get => _graph; set => _graph = value; }
    public int Start { get => _Start; set => _Start = value; }
    public int End { get => _End; set => _End = value; }
}
