using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electron : MonoBehaviour
{
    public float moveSpeed = 10f;
    public  List<Transform> path;
    public void FollowPath(List<Transform> path)
    {
        StartCoroutine(FollowPathCoroutine(path));
    }
    IEnumerator FollowPathCoroutine(List<Transform> path)
    {
        int pos = 0;
        Transform target;
        while (pos < path.Count)
        {
            target = path[pos];
            while (Vector3.Distance(transform.position, target.position) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                yield return null;
            }
            pos += 1;
        }
        Destroy(this.gameObject);
    }
    public void MoveTo(Transform target)
    {
        StartCoroutine(MoveToCoroutine(target));
    }
    
    IEnumerator MoveToCoroutine(Transform target)
    {
        while (Vector3.Distance(transform.position, target.position) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
