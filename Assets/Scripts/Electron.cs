using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Electron : MonoBehaviour
{
    public float moveSpeed = 10f;
    public void FollowPath(List<Point> path)
    {
        StartCoroutine(FollowPathCoroutine(path));
    }
    IEnumerator FollowPathCoroutine(List<Point> path)
    {
        int pos = 0;
        Transform target;
        
        while (pos < path.Count-1)
        {
            Debug.Log("Start now with POS " + pos);

            List<Vector3> positions = PathManger.GetPathPointsBetween(path[pos].ID, path[pos + 1].ID).ToList();
            foreach (Vector3 p in positions) Debug.Log(p);
            foreach (Vector3 nextTargetPos in positions)
            {
                Debug.Log("cURRENT POS " + pos);
                Debug.Log("nexttarget" + nextTargetPos);
                while (Vector3.Distance(transform.position, nextTargetPos) > 0.01f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, nextTargetPos, moveSpeed * Time.deltaTime);
                    yield return null;
                }
               // Debug.Log("Puse to read");
                //yield return new WaitForSeconds(3f);
            }
            Debug.Log("completed my first path between" + pos + (pos + 1));
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
