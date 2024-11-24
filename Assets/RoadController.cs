using System.Collections;
using System.Collections.Generic;
using Mono.Cecil.Cil;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Video;

public class RoadController : MonoBehaviour, RoadTrafficInterface
{
    public PlayerController player;
    public Sanity sanity;

    public GameObject playerOrigin;
    public GameObject leftWaypoint;
    public GameObject rightWaypoint;

    [SerializeField] float minDriftSpeed;
    [SerializeField] float maxDriftSpeed;
    [SerializeField] float minDelay;
    [SerializeField] float maxDelay;
    [SerializeField] float originDistanceThreshold;
    private float delay; 
    private int dir; // 0 left, 1 right
    private float speed;
    private bool returning;
    void Awake()
    {
        player = FindFirstObjectByType<PlayerController>();
        if (player == null) Debug.LogError($"[{gameObject}]: {nameof(player)} not found in the scene!");
        sanity = FindFirstObjectByType<Sanity>();
        if (sanity == null) Debug.LogError($"[{gameObject}]: {nameof(sanity)} not found in the scene!");
    }
    void Start()
    {
        StartCoroutine(GenerateValuesCoroutine());
    }

    void Update()
    {
        if (!returning)
        {
            MoveToWaypoint();
        }
        else
        {
            ReturnToOrigin();
        }

        HandlePlayerInput();
    }

    private void MoveToWaypoint()
    {
        GameObject targetWaypoint = GetDirection(dir);

        if (targetWaypoint == null)
        {
            Debug.LogError("Target waypoint not found");
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.transform.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetWaypoint.transform.position) < originDistanceThreshold)
        {
            Debug.Log("Reached edge, death.");
            sanity.Die();
            // returning = true;
        }
    }

    private void ReturnToOrigin()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerOrigin.transform.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, playerOrigin.transform.position) <= originDistanceThreshold)
        {
            Debug.Log("Returned to origin.");
            returning = false;
        }
    }


    Animator animator;
    private void HandlePlayerInput()
    {
        // if ((Input.GetKeyDown(KeyCode.A) && dir == 1) || (Input.GetKeyDown(KeyCode.D) && dir == 0))
        // {
        //     Debug.Log("Player input correct! Returning to origin.");
        //     returning = true;
        // }
        if(Input.GetKeyDown(KeyCode.A) && dir == 1)
        {
            Debug.Log("Player input correct! Returning to origin.");
            returning = true;
            animator.SetTrigger("isSteeringLeft");
        }
        else if(Input.GetKeyDown(KeyCode.D) && dir == 0)
        {
            Debug.Log("Player input correct! Returning to origin.");
            returning = true;
            animator.SetTrigger("isSteeringRight");
        }
    }

    IEnumerator GenerateValuesCoroutine()
    {
        while (true)
        {
            if (!returning)
            {
                dir = GetRandomDirection();
                speed = GetRandomSpeed();
                delay = GetRandomDelay();

                Debug.Log($"Generated Direction: {(dir == 0 ? "Left" : "Right")}, Speed: {speed}, Delay: {delay}");
            }
            yield return new WaitForSeconds(delay);
        }
    }

    public int GetRandomDirection()
    {
        return Random.Range(0, 2); // 0 for left, 1 for right
    }

    public float GetRandomSpeed()
    {
        return Random.Range(minDriftSpeed, maxDriftSpeed);
    }

    public float GetRandomDelay()
    {
        return Random.Range(minDelay, maxDelay);
    }

    public GameObject GetDirection(int dirInt)
    {
        switch (dirInt)
        {
            case 0:
                return leftWaypoint;
            case 1:
                return rightWaypoint;
            default:
                Debug.LogError("Invalid");
                return null;
        }
    }
}
