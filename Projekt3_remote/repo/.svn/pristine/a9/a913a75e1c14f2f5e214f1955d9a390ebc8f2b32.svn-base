using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToExit : MonoBehaviour
{

    public Transform exitPosition;

    [SerializeField]
    public float speed = 6f;

    Vector3[] path;
    //waypoints index
    int targetIndex;

    public delegate void OnExitReach();
    public event OnExitReach ExitReach;


    // Start is called before the first frame update
    void Start()
    {
        ExitReach += ReactOnReachedExit;

    }

    // Update is called once per frame
    void Update()
    {
         
    }

    public void GoOut()
    {
        RequestPathManager.RequestPath(transform.position, exitPosition.position, OnPathFound);
       
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
            Debug.Log("Found_Path");
        }
    }



    IEnumerator FollowPath()
    {
        if (path.Length > 0)
        {
            Vector3 currentWaypoint = path[0];
            while (true)
            {
                if (transform.position == currentWaypoint)
                {
                    targetIndex++;
                    if (targetIndex >= path.Length)
                    {
                        ExitReach?.Invoke();
                        //playerAnimator.SetBool("isWalking", false);
                        yield break;
                        
                    }
                    currentWaypoint = path[targetIndex];
                }
                //playerAnimator.SetBool("isWalking", true);

                //playerSprite.flipX = (currentWaypoint - transform.position).normalized.x < 0;

                transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, speed * Time.deltaTime);
                yield return null;
            }
        }
    }

    void ReactOnReachedExit()
    {
        Destroy(gameObject);
    }


}
