using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveToClickInput : MonoBehaviour
{

    Animator playerAnimator;
    SpriteRenderer playerSprite;

    [SerializeField]
    public float speed = 6f;

    Vector3[] path;

    //waypoints index
    int targetIndex; 

    private Vector2 targerPosition;

    void Awake()
    {
        targerPosition = transform.position;
        playerAnimator = GetComponent<Animator>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    public void OnPathFound(Vector3[] newpath, bool pathSuccesfull)
    {
        if (pathSuccesfull)
        {
            playerAnimator.SetBool("isWalking", false);
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
            if (!EventSystem.current.IsPointerOverGameObject()) //! prevent character to walk when clicking on inventory
            {
                Debug.Log(Input.mousePosition);
                targerPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RequestPathManager.RequestPath(transform.position, targerPosition, OnPathFound);
            }
        }

    }

    /// <summary>
    /// Follow given path
    /// </summary>
    /// <returns></returns>
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
                        playerAnimator.SetBool("isWalking", false);
                        yield break;
                    }
                    currentWaypoint = path[targetIndex];
                }
                playerAnimator.SetBool("isWalking", true);

                playerSprite.flipX = (currentWaypoint - transform.position).normalized.x < 0;

                transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, speed * Time.deltaTime);
                yield return null;
            }
         }
    }


    public void ApproachInteractable(Vector3 targetPosition)
    {
            RequestPathManager.RequestPath(transform.position, targetPosition, OnPathFound);       
    }




}
