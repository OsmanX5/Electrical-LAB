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
        for (int i = 0; i < n; i++) AddPoint(i);
        
    }
    public void AddPoint(int id)
    {
        roots.Add(id);
        Joints[id] =  new HashSet<int>() { id };
        JointsCount += 1;
    }
    public int Find(int x)
    {
        while (x != roots[x])
            x = roots[x];
        return x;
    }
    public void Union(int master,int sleve)
    {
        int roota = Find(master);
        int rootb = Find(sleve);
        if(roota != rootb)
        {
            roots[rootb] = roota;
            Joints[roota].UnionWith(Joints[rootb]);
            Joints.Remove(rootb);
            JointsCount -= 1;
            return;
        }
    }
    public bool IsConnected(int a, int b)
    {
        return Find(a) == Find(b);
    }
    public int[] GetJointsHead() => Joints.Keys.ToArray();
    public int[] GetJointPoints(int jointHead) => Joints[jointHead].ToArray();
}
