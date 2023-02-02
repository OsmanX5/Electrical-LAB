using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Electron : MonoBehaviour
{
    public float moveSpeed = 10f;
    public void AddToManger()
    {
        ElectronsManger.AddElectron(this);
    }
    public void FollowPath(Point[] path)
    {
        StartCoroutine(FollowPathCoroutine(path));
    }
    IEnumerator FollowPathCoroutine(Point[] path)
    {
        int pos = 0;
        Transform target;
        while (pos < path.Length)
        {
            target = path[pos].transform;
            while (Vector3.Distance(transform.position, target.position) > 0.001f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                    yield return null;
                }
            pos += 1;
        }
        delet();
    }
    public void delet() {
        ElectronsManger.RemoveElectron(this);
        Destroy(this.gameObject);
    }
        
    


}
