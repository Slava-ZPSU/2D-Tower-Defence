using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Visible fields
    [SerializeField]
    private List<Vector2> wayPoints;
    [SerializeField]
    private float hp = 10f;
    [SerializeField]
    private float damage = 3f;
    [SerializeField]
    private Animator animator;

    // Invisible fields
    private int currentPointID = 0;
    private Vector2 finishPoint;
    private Vector2 direction;

    private List<string> animationStates = new List<string> { 
        "Walk_U_Slime",
        "Walk_D_Slime",
        "Walk_R_Slime",
        "Walk_L_Slime",
        "Hit_Slime",
        "Death_U_Slime",
        "Death_D_Slime",
        "Death_R_Slime",
        "Death_L_Slime"
    };

    private void Start()
    {
        animator = GetComponent<Animator>();

        finishPoint = wayPoints[wayPoints.Count - 1];
    }
    private void Update()
    {
        ChangeTarget();

        PlayAnimation();

        if ((Vector2)transform.position == finishPoint) {
            EnterToFinish();
        }
    }
    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        transform.position = Vector2.MoveTowards(transform.position, wayPoints[currentPointID], 0.1f);
    }

    private void PlayAnimation() 
    { 
        if (direction == Vector2.up) {
            animator.Play(animationStates[0]);
        } else if (direction == Vector2.down) {
            animator.Play(animationStates[1]);
        } else if (direction == Vector2.right) {
            animator.Play(animationStates[2]);
        } else if (direction == Vector2.left) {
            animator.Play(animationStates[3]);
        }
    }

    private void ChangeTarget()
    {
        if ((Vector2)transform.position == wayPoints[currentPointID] && currentPointID != wayPoints.Count - 1) {
            currentPointID++;
            direction = (wayPoints[currentPointID] - (Vector2)transform.position).normalized;
        }
    }

    public void FillWayPoints(List<Transform> wayPointsList) {
        foreach (var wayPoint in wayPointsList) {
            Debug.Log(wayPoint.position);
            wayPoints.Add((Vector2)wayPoint.position);
        }
    }

    private void EnterToFinish()
    {
        Destroy(gameObject);
    }
}
