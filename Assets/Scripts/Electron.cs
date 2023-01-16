using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electron : MonoBehaviour
{
    public float moveSpeed = 10f;
    public Transform target;
    bool reachedTheTarget = false;
    public  List<Transform> path;
    private void Start()
    {
        FollowPath(path);
    }
    public void FollowPath(List<Transform> path)
    {
        StartCoroutine(FollowPathCoroutine(path));
    }
    IEnumerator FollowPathCoroutine(List<Transform> path)
    {
        int pos = 0;
        while (pos < path.Count)
        {
            if (Vector3.Distance(transform.position, path[pos].position) < 0.1f)
            {
                pos++;
                if (reachedTheTarget == true) 
                    MoveTo(path[pos]);
                yield return new WaitForSeconds(0.01f);
            }
        }
    }
    public void MoveTo(Transform target)
    {
        StartCoroutine(MoveToCoroutine(target));
    }
    
    IEnumerator MoveToCoroutine(Transform target)
    {
        reachedTheTarget = false;
        while (Vector3.Distance(transform.position, target.position) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            yield return null;
        }
        reachedTheTarget = true;
    }
}
