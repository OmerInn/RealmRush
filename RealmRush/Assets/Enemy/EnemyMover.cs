using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<WayPoint> path = new List<WayPoint>();
    [SerializeField] [Range(0f, 5f)] float speed = 1f;

    Enemy enemy;

     void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(followPath());
    }
    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }
    void FindPath()
    {
        path.Clear();
        // GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Path");
        GameObject parent = GameObject.FindGameObjectWithTag("Path"); //tiles:fayans

        // foreach (GameObject waypoint in waypoints)
        foreach (Transform child in parent.transform)
        {
            // path.Add(waypoint.GetComponent<WayPoint>());
            WayPoint waypoint = child.GetComponent<WayPoint>();

            if (waypoint != null)
            {
                path.Add(waypoint);
            }


        }
    }
    void FinishPath()
    {
        gameObject.SetActive(false);
        enemy.StealGold();//yol bittiðinde para gider.
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }


    IEnumerator followPath()
    {
        foreach (WayPoint wayPoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = wayPoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPosition);

            while (travelPercent<1)
            {
                travelPercent += Time.deltaTime*speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
        FinishPath();
    }
}
