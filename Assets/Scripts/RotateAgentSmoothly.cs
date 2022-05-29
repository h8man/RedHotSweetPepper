using System.Collections;
using UnityEngine;
using UnityEngine.AI;

//***********************************************************************************
// Contributed by author @Lazy_Sloth from unity forum (https://forum.unity.com/)
//***********************************************************************************

public class RotateAgentSmoothly : MonoBehaviour
{
    private NavMeshAgent agent;
    private Vector2 nextWaypoint;
    private float angleDifference;
    private float targetAngle;
    private float rotateSpeed;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        rotateSpeed = 80f;
    }

    void Update()
    {
        if (agent.hasPath)
        {
            if (nextWaypoint != (Vector2)agent.path.corners[1])
            {
                StartCoroutine("RotateToWaypoints");
                nextWaypoint = agent.path.corners[1];
            }
        }
    }

    IEnumerator RotateToWaypoints()
    {
        Vector2 targetVector = agent.path.corners[1] - transform.position;
        angleDifference = Vector2.SignedAngle(transform.up, targetVector);
        targetAngle = transform.localEulerAngles.z + angleDifference;

        if (targetAngle >= 360) { targetAngle -= 360; }
        else if (targetAngle < 0) { targetAngle += 360; }

        while (transform.localEulerAngles.z < targetAngle - 0.1f || transform.localEulerAngles.z > targetAngle + 0.1f)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, targetAngle), rotateSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
