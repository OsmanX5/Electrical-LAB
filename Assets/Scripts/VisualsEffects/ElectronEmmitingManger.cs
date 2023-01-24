using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ElectronEmmitingManger : MonoBehaviour
{
    public GameObject ElectronPrefab;
    public float EmmitingFreq = 4f;
    bool isEmmiting = false;
    void Start()
    {
        GameManger.GraphManger.OnCircuitClose += StartEmmiting;
    }
    void EmmitElectron(Point[] path)
    {
        var electron = Instantiate(ElectronPrefab, PointsManger.GetPoint(GameManger.GraphManger.StartID).transform.position, Quaternion.identity).GetComponent<Electron>();
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
        while (isEmmiting)
        {
            var pathes = GameManger.GraphManger.GetAllPathesOfBattery();
            foreach (var path in pathes)
            {
                Point[] ElectronPath = PointsConverter.ToPoints(path);
                EmmitElectron(ElectronPath);
                yield return new WaitForSeconds(1.0f / (EmmitingFreq *(pathes.Count*0.2f +1)));
            }
        }
    }
    
    
}
