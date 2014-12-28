using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mover : MonoBehaviour
{
    private Vector3 direction;
    private Vector3 moveVector;
    private float moveSpeed = 1f;
    private float minDistance = 0.1f;
    private bool waypointIsSet = false;

    private Vector3 currentWaypoint;
    private int currentIndex;
    private List<Vector3> waypoints = new List<Vector3>();

    public void SetWaypoints(List<Vector3> _waypoints)
    {
        waypoints = _waypoints;
        currentWaypoint = waypoints[0];
        currentIndex = 0;
        waypointIsSet = true;
    }

    void Update()
    {
        if (GameObject.Find("GameState").GetComponent<State>().Running && waypointIsSet)
        {
            UpdatePosition();
            CheckPosition();
        }
    }

    private void UpdatePosition()
    {
        direction = currentWaypoint - transform.position;
        moveVector = direction.normalized * moveSpeed * Time.deltaTime;
        transform.position += moveVector;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 4 * Time.deltaTime);
    }

    private void CheckPosition()
    {
        if (Vector3.Distance(currentWaypoint, transform.position) < minDistance)
        {
            ++currentIndex;
            if (currentIndex > waypoints.Count - 1)
            {
                Destroy(gameObject);
                return;
            }
            currentWaypoint = waypoints[currentIndex];
        }
    }
}
