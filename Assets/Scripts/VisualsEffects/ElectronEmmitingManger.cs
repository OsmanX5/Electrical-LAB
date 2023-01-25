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
        GameManger.GraphManger.OnCircuitOpen += StopEmmiting;
    }
    void EmmitElectron(Point[] path)
    {
        Vector3 CreatePosition = PointsManger.GetPoint(GameManger.GraphManger.StartID).transform.position;
        var electronObj = Instantiate(ElectronPrefab, CreatePosition, Quaternion.identity);
        electronObj.SetActive(true);
        var electron = electronObj.GetComponent<Electron>();
        electron.AddToManger();
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

    void StopEmmiting()
    {
        Debug.Log("StopEmmiting");
        isEmmiting = false;
        ElectronsManger.DeletAllElectrons();
    }

}
