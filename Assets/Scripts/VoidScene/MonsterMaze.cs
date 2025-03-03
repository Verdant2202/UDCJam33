using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;
public class MonsterMaze : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform player;
    [SerializeField] Transform[] WarpPoints;
    [SerializeField] float Speed;
    [SerializeField] float RunSpeed;

    bool enabled = false;
    Transform currentWarpPoint;
    [SerializeField] float minimumTeleportInterval = 10f;
    private float teleportTimer = 0f;

    [SerializeField] float minDistanceToTeleport = 5f;

    [SerializeField] float runDuration = 4f;
    float runTimer = 0;
    [SerializeField] float runRNGInterval = 7f;

    [Range(0f, 1f)][SerializeField] float runProbability = 0.2f;

    public void EnableMonster()
    {
        enabled = true;
    }
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

    void SetRunning(bool set)
    {
        if(set == true)
        {
            agent.speed = RunSpeed;
        }
        else
        {
            agent.speed = Speed;
        }

        anim.SetBool("running", set);
    }
    IEnumerator EnableRun()
    {
        SetRunning(true);
        yield return new WaitForSeconds(runDuration);
        SetRunning(false);
    }


    // Start is called before the first frame update
    void Start()
    {
        enabled = false;
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

    void HandleRun()
    {
        if(runTimer > runRNGInterval)
        {
            float RNG = Random.Range(0f, 1f);
            if(RNG <= runProbability)
            {
                StartCoroutine(EnableRun());
            }
            runTimer = 0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(enabled)
        {
            agent.SetDestination(player.position);
            teleportTimer += Time.deltaTime;
            runTimer += Time.deltaTime;
            HandleTeleportation();
            HandleRun();
        }

    }
}
