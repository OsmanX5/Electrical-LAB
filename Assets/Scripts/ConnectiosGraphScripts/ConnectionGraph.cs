using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class ConnectionGraph : MonoBehaviour
{
    public static Dictionary<int,List<ConnectionPoint>> AdjacencyList;
    public static DisJointSet DisJointSet;
    [SerializeField] TMP_Text TextTMP;
    [SerializeField] TMP_Text TMP_DISJOINT;
    private void Awake()
    {
        AdjacencyList = new Dictionary<int, List<ConnectionPoint>>();
        DisJointSet = new DisJointSet(0);
        this.AddComponent<ConnectionGraphBuilder>();
    }
    private void FixedUpdate()
    {
        UpdateTMPtext();
    }

    void UpdateTMPtext()
    {
        TextTMP.text = GetAdjacencyListText();
        TMP_DISJOINT.text = DisJointSet.GetDisjointSetText();
    }
    public static string GetAdjacencyListText()
    {
        string adjacencyListSTR = "";
        foreach (var item in AdjacencyList)
        {
            adjacencyListSTR += item.Key + " : [";
            foreach (var connectionPoint in item.Value)
            {
                adjacencyListSTR += $" ({connectionPoint.point.ID} , {connectionPoint.resistance} ) ";
            }
            adjacencyListSTR += " ] \n";
        }
        return adjacencyListSTR;
    }

    public static bool IsInGraph(Point point) => IsInGraph(point.ID);
    public static bool IsInGraph(int ID)=> AdjacencyList.ContainsKey(ID);
    
}
