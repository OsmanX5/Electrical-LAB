using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ElectronEmmitingManger : MonoBehaviour
{
    public GameObject ElectronPrefab;
    public float EmmitingFreq = 0.2f;
    List<Electron> electrons = new List<Electron>();
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
    void EmmitElectron(List<Point> path)
    {
        Debug.Log("Emmiting electron");
        var electron = Instantiate(ElectronPrefab, PointsManger.GetPointByID(ConnectionGraph.StartID).transform.position, Quaternion.identity).GetComponent<Electron>();
        electrons.Add(electron);
        electron.FollowPath(path);
    }
    void StartEmmiting()
    {
        StartCoroutine(EmmitingCoroutien());
    }
    IEnumerator EmmitingCoroutien()
    {
        while(true)
        {
            for(int i=0;i< ConnectionGraphPathCalculator.AllPathesOfBattery.Count; i++)
            {
                EmmitElectron(ConvertPathID2Points(ConnectionGraphPathCalculator.AllPathesOfBattery[i]));
            }
            yield return new WaitForSeconds(1.0f /EmmitingFreq);
        }
    }
    
    
}
