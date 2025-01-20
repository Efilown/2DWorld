using UnityEngine;
using System.Collections.Generic;

public class GhostBehaviour : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float speed = 5f;

    [SerializeField] private float timerStart = 5f;

    [SerializeField] private List<Vector3> waypoints;
    [SerializeField] private float timeSinceStart = 0f;
    [SerializeField] private int currentWaypoint = 0;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // every 0.5 seconds
        InvokeRepeating("UpdatePath", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceStart += Time.deltaTime;
        if (timeSinceStart >= timerStart) {
            if (timeSinceStart >= timerStart + (currentWaypoint * 0.5f)) {
                currentWaypoint++;
                waypoints.RemoveAt(0);
            } else {
                transform.position = Vector3.MoveTowards(transform.position, waypoints[0], speed * Time.deltaTime);
            }
        }
    }

    void UpdatePath()
    {
        waypoints.Add(player.position);
    }
}
