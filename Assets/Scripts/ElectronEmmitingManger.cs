using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ElectronEmmitingManger : MonoBehaviour
{
    public GameObject ElectronPrefab;
    public float EmmitingFreq = 4f;
    List<Electron> electrons = new List<Electron>();
    bool isEmmiting = false;
    void Start()
    {
        ConnectionGraphPathCalculator.OnCircuitClose += StartEmmiting;
    }
    List<Transform> ConvertPathID2Transform(List<int> pathIDs)
    {
        List<Transform> path = new List<Transform>();
        foreach (int id in pathIDs)
        {
            path.Add(PointsManger.GetPointByID(id).transform);
        }
        return path;
    }
    List<Point> ConvertPathID2Points(List<int> pathIDs)
    {
        List<Point> path = new List<Point>();
        foreach (int id in pathIDs)
        {
            path.Add(PointsManger.GetPointByID(id));
        }
        return path;
    }
    void EmmitElectron(List<int> pathIDs)
    {
        EmmitElectron(ConvertPathID2Points(pathIDs));
    }
    void EmmitElectron(List<Point> path)
    {
        Debug.Log("Emmiting electron");
        var electron = Instantiate(ElectronPrefab, PointsManger.GetPointByID(ConnectionGraph.StartID).transform.position, Quaternion.identity).GetComponent<Electron>();
        electrons.Add(electron);
        electron.FollowPath(path);
    }
    void StartEmmiting()
    {
        if(!isEmmiting)
            StartCoroutine(EmmitingCoroutien());
    }
    IEnumerator EmmitingCoroutien()
    {
        isEmmiting = true;
        while (true)
        {
            var pathes = ConnectionGraphPathCalculator.AllPathesOfBattery;
            foreach (var path in pathes)
            {
                
                EmmitElectron(path);
                yield return new WaitForSeconds(1.0f / (EmmitingFreq *(pathes.Count*0.2f +1)));
            }
        }
    }
    
    
}
