using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToClickInput : MonoBehaviour
{

    [SerializeField]
    //public Transform target;
    //[SerializeField]
    public float speed = 6f;
    Vector3[] path;
    int targetIndex; //waypoints index

    private Vector2 targerPosition;

    void Awake()
    {
        targerPosition = transform.position;
    }

    public void OnPathFound(Vector3[] newpath, bool pathSuccesfull)
    {
        if (pathSuccesfull)
        {
            //Assign path from Request path callback to current object path
            path = newpath;
            targetIndex = 0;
            StopCoroutine("FollowPath");
            StartCoroutine("FollowPath");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            targerPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //target.position = targerPosition;
            RequestPathManager.RequestPath(transform.position, targerPosition, OnPathFound);
        }

    }

    /// <summary>
    /// Follow given path
    /// </summary>
    /// <returns></returns>
    IEnumerator FollowPath()
    {
        Vector3 currentWaypoint = path[0];
        while (true)
        {
            if(transform.position == currentWaypoint)
            {
                targetIndex++;
                if(targetIndex >= path.Length)
                {
                    yield break;
                }
                currentWaypoint = path[targetIndex];
            }
            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, speed * Time.deltaTime);
            yield return null;
        }
    }

}
