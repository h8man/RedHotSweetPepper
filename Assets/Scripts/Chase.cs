using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chase : MonoBehaviour
{
    public GameObject target;
    private NavMeshAgent agent;
    private bool stop;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            agent.speed += 0.1f;
        }
        if ((transform.position - target.transform.position).magnitude < 1 && !stop)
        {
            stop = true;
            target.GetComponent<Navigate>().enabled = false;
            Canvas canvas = FindObjectOfType<Canvas>();
            var gameOver = canvas.transform.Find("Panel");
            gameOver.gameObject.SetActive(true);
            var score = canvas.transform.Find("Score");
            score.SendMessage("Stop", true);
        }
        agent.SetDestination(target.transform.position);
        Navigate.DebugDrawPath(agent.path.corners);
    }
}
