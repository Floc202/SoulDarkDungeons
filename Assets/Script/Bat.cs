using Assets.Script;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    public float flySpeed = 2f;
    public float waypointReachedDistance = 0;
    public DetectionZone biteDetectionZone;
    public List<Transform> waypoints;

    Animator animator;
    Rigidbody2D rb;
    Damageble damageble;

    Transform nextWaypoint;
    int waypointNum = 0;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        damageble = GetComponent<Damageble>();
    }

    private void Start()
    {
        nextWaypoint = waypoints[waypointNum];
    }

    public bool _hasTarget = false;
    
    public bool HasTarget
    {
        get { return _hasTarget; }
        private set
        {
            _hasTarget = value;
            animator.SetBool(AnimationStrings.hasTarget, _hasTarget);
        }
    }

    public bool CanMove
    {
        get
        {
            return animator.GetBool(AnimationStrings.canMove);
        }
    }

    // Update is called once per frame
    void Update()
    {
        HasTarget = biteDetectionZone.detectedColliders.Count > 0;
    }

    private void FixedUpdate()
    {
        if (damageble.IsAlive)
        {
            if (CanMove)
            {
                Flight();
            }
            else 
            {
                rb.velocity = Vector3.zero;
            }
        }
    }

    private void Flight()
    {
        //fly to next waypoint
        Vector2 directionToWaypoint = (nextWaypoint.position - transform.position).normalized;

        //check reaching waypoints
        float distance = Vector2.Distance(nextWaypoint.position, transform.position);

        rb.velocity = directionToWaypoint * flySpeed;
        UpdateDirection();

        if(distance < waypointReachedDistance)
        {
            waypointNum++;

            if(waypointNum >= waypoints.Count)
            {
                waypointNum = 0;
            }

            nextWaypoint = waypoints[waypointNum];
        }
    }

    private void UpdateDirection()
    {
        Vector3 locScale = transform.localScale;

        if (transform.localScale.x > 0)
        {
            //facing left
            if (rb.velocity.x > 0)
            {
                locScale = new Vector3(-1 * locScale.x, locScale.y, locScale.z);
            }
        }
        else {
            if (rb.velocity.x < 0)
            {
                locScale = new Vector3(-1 * locScale.x, locScale.y, locScale.z);
            }
        }
    }
}
