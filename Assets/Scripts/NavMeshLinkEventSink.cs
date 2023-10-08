using NavMeshPlus.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class NavMeshLinkEventSink : MonoBehaviour
{
    public NavMeshAgent agent;
    public UnityEvent<NavMeshLink> onLink;

    private IEnumerator Start()
    {
        while (true)
        {
            if (agent.isOnOffMeshLink)
            {
                OffMeshLinkData data = agent.currentOffMeshLinkData;

                if (data.offMeshLink)
                {
                    Debug.Log("on OFFmeshLink: " + data.offMeshLink.name, data.offMeshLink.gameObject);
                }
                else if (agent.navMeshOwner is NavMeshLink)
                {
                    var link = (NavMeshLink)agent.navMeshOwner;
                    Debug.Log("on NavMeshLink: " + link.name, link.gameObject);
                    yield return (processTransition(link));
                }
            }
            yield return null;
        }
    }

    private IEnumerator processTransition(NavMeshLink link)
    {
        onLink.Invoke(link);
        while (agent.isOnOffMeshLink)
        {
            yield return null;
        }
    }
}
