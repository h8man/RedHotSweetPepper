using UnityEngine;
using UnityEngine.AI;

//***********************************************************************************
// Contributed by author @Lazy_Sloth from unity forum (https://forum.unity.com/)
//***********************************************************************************

public class RotateAgentInstantly : MonoBehaviour
{
    private NavMeshAgent agent;
    private Vector3 nextWaypoint;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        if (agent.hasPath)
        {
            if (nextWaypoint != agent.path.corners[1])
            {
                RotateToPoint(agent.path.corners[1]);
                nextWaypoint = agent.path.corners[1];
            }
        }
    }

    private void RotateToPoint(Vector3 targetPoint)
    {
        Vector3 targetVector = targetPoint - transform.position;
        float angleDifference = Vector2.SignedAngle(transform.up, targetVector);
        transform.rotation = Quaternion.Euler(0, 0, transform.localEulerAngles.z + angleDifference);
    }
}
