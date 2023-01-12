using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using UnityEngine;

public class DisJointSet 
{
    public int JointsCount;
    List<int> roots;
    public Dictionary<int, HashSet<int>> Joints { get; set ; }

    public DisJointSet(int n)
    {
        JointsCount = n;
        roots = new List<int>();
        Joints = new Dictionary<int, HashSet<int>>();
        for (int i = 0; i < n; i++)
        {
            AddPoint(i);
        }
    }
    public void AddPoint(int id)
    {
        Debug.Log("AddingPoint: " + id + " to DisJointSet");
        roots.Add(id);
        Joints[id] =  new HashSet<int>() { id };
        JointsCount += 1;
        Debug.Log("Dis joint set after adding : " + id);
        Debug.Log(GetDisjointSetText());
    }
    int Find(int x)
    {
        //Debug.Log("Searching for: " + x);
        while (x != roots[x])
            x = roots[x];
        //Debug.Log("The root is : " + x);
        return x;
    }
    public void Union(int master,int sleve)
    {
        Debug.Log("Unioning: " + master + " and " + sleve);
        int roota = Find(master);
        int rootb = Find(sleve);
        if(roota != rootb)
        {
            Debug.Log("Start union");
            roots[rootb] = roota;
            Joints[roota].UnionWith(Joints[rootb]);
            Joints.Remove(rootb);
            JointsCount -= 1;
            Debug.Log("Succsfully Connected Joints Count now is" + JointsCount);
            Debug.Log(GetDisjointSetText());
            Debug.Log("Successfuly Unioned " + master + " and " + sleve);
            return;
        }
        Debug.Log("Joints are already connected");
    }
    public bool IsConnected(int a, int b)
    {
        return Find(a) == Find(b);
    }
    public string GetDisjointSetText()
    {
        string result = "";
        foreach (var pair in Joints)
        {
            result += "Joint: " + pair.Key + " Contains: ";
            foreach (var point in pair.Value)
            {
                result += point + " ";
            }
            result += "\n";
        }
        return result;
    }

    public int[] GetJointsHead() => Joints.Keys.ToArray();
    public int[] GetJointPoints(int jointHead) => Joints[jointHead].ToArray();
}
