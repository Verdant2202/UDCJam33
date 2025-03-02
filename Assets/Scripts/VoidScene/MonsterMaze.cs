using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;
public class MonsterMaze : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform player;
    [SerializeField] Transform[] WarpPoints;
   
    Transform currentWarpPoint;
    [SerializeField] float minimumTeleportInterval = 10f;
    private float teleportTimer = 0f;

    [SerializeField] float minDistanceToTeleport = 5f;

    public static float GetPathDistance(Vector3 start, Vector3 end)
    {
        NavMeshPath path = new NavMeshPath();
        if (NavMesh.CalculatePath(start, end, NavMesh.AllAreas, path))
        {
            float totalDistance = 0f;
            for (int i = 1; i < path.corners.Length; i++)
            {
                totalDistance += Vector3.Distance(path.corners[i - 1], path.corners[i]);
            }
            return totalDistance;
        }
        return Mathf.Infinity; // If no valid path, return a large number
    }

    private void TeleportToWarpPoint(Transform warppoint)
    {
        agent.Warp(warppoint.position);
    }

    Transform GetNearestWarpPoint(Transform t)
    {
        return WarpPoints.Where(x => GetPathDistance(player.position, x.position) > minDistanceToTeleport).OrderBy(x => GetPathDistance(t.position, x.position)).FirstOrDefault();
    }
    // Start is called before the first frame update
    void Start()
    {
        teleportTimer = 0f;
        currentWarpPoint = GetNearestWarpPoint(transform);
    }

    void HandleTeleportation()
    {
        if(GetPathDistance(player.position, transform.position) <= minDistanceToTeleport)
        {
            return;
        }
        Transform closestWarpPoint = GetNearestWarpPoint(player);
        if (closestWarpPoint == null)
        {
            return;
        }

        if (currentWarpPoint != closestWarpPoint && teleportTimer >= minimumTeleportInterval && (GetPathDistance(transform.position, player.position) > GetPathDistance(closestWarpPoint.position, player.position)))
        {
            TeleportToWarpPoint(closestWarpPoint);
            currentWarpPoint = closestWarpPoint;
            teleportTimer = 0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.position);
        teleportTimer += Time.deltaTime;

        HandleTeleportation();
      
       

    }
}
