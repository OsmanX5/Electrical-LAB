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
    void EmmitElectron(Point[] path)
    {
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
                Point[] ElectronPath = PointsConverter.ToPoints(path);
                EmmitElectron(ElectronPath);
                yield return new WaitForSeconds(1.0f / (EmmitingFreq *(pathes.Count*0.2f +1)));
            }
        }
    }
    
    
}
