using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;
public class MonsterMaze : Monster
{
    [SerializeField] MazeManager mazeManager;

    [SerializeField] NavMeshAgent agent;
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

    [SerializeField] SFXSO footstepsSFX;
    [SerializeField] SFXSO runFootstepsSFX;
    [SerializeField] AudioSource footstepsAudioSource;
    [SerializeField] AudioSource runFootstepsAudioSource;
    bool running;

    [SerializeField] float MinDist = 3f;
    [SerializeField] float MaxDist = 10f;

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
        return WarpPoints.Where(x => GetPathDistance(playerTransform.position, x.position) > minDistanceToTeleport).OrderBy(x => GetPathDistance(t.position, x.position)).FirstOrDefault();
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
        running = true;
        yield return new WaitForSeconds(runDuration);
        runTimer = 0f;
        running = false;
        SetRunning(false);
    }

    public void MazeJumpscare()
    {
        agent.enabled = false;
        enabled = false;
        StartCoroutine(Jumpscare());
    }

    // Start is called before the first frame update
    void Start()
    {
        running = false;
        footstepsAudioSource.clip = footstepsSFX.clip;
        runFootstepsAudioSource.clip = runFootstepsSFX.clip;
        enabled = false;
        teleportTimer = 0f;
        currentWarpPoint = GetNearestWarpPoint(transform);
    }

    void HandleTeleportation()
    {
        if(GetPathDistance(playerTransform.position, transform.position) <= minDistanceToTeleport)
        {
            return;
        }
        Transform closestWarpPoint = GetNearestWarpPoint(playerTransform);
        if (closestWarpPoint == null)
        {
            return;
        }

        if (currentWarpPoint != closestWarpPoint && teleportTimer >= minimumTeleportInterval && (GetPathDistance(transform.position, playerTransform.position) > GetPathDistance(closestWarpPoint.position, playerTransform.position)))
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

    public void ControlFootstepsVolume()
    {
        float distance = Vector3.Distance(transform.position, playerTransform.position);

        // Clamp the distance to be between MinDist and MaxDist
        float normalizedDistance = Mathf.Clamp01((MaxDist - distance) / (MaxDist - MinDist));

        // Calculate new volume (100% at MinDist, 0% at MaxDist)
        footstepsAudioSource.volume = footstepsSFX.naturalVolume * SFXManager.Instance.globalSFXVolume * normalizedDistance;
        runFootstepsAudioSource.volume = runFootstepsSFX.naturalVolume * SFXManager.Instance.globalSFXVolume * normalizedDistance;
    }

    // Update is called once per frame
    void Update()
    {
        footstepsAudioSource.enabled = enabled;
        runFootstepsAudioSource.enabled = running;
        if (running)
        {
            footstepsAudioSource.enabled = false;
        }
        ControlFootstepsVolume();
        if(enabled)
        {
            agent.SetDestination(playerTransform.position);
            teleportTimer += Time.deltaTime;
            runTimer += Time.deltaTime;
            HandleTeleportation();
            HandleRun();
        }
        if (Time.timeScale == 0f)
        {
            footstepsAudioSource.enabled = false;
            runFootstepsAudioSource.enabled = false;
        }


    }
}
