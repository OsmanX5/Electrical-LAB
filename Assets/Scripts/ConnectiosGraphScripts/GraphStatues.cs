using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
[Serializable]
public struct Connection
{
    public int Key;
    public string values;
}
public class GraphStatues : MonoBehaviour
{
    public List<Connection> connections = new List<Connection>();
    public TMP_Text text;
    void Update()
    {
        connections = buildConnection();
        text.text = GameManger.GraphManger.Graph.ToString();
    }
    List<Connection> buildConnection()
    {
        List<Connection> res = new List<Connection>();
        foreach (var item in GameManger.GraphManger.Graph.GetAdjacencyList())
        {
            Connection connection = new Connection();
            connection.Key = item.Key;
            connection.values = String.Join(" - ", (item.Value.Select(x => x.ToString())).ToList());
            res.Add(connection);
            
        }
        return res;
    }
    
}
