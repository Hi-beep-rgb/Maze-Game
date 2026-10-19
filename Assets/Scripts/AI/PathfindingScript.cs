using UnityEngine;
using UnityEngine.AI;

public class PathfindingScript : MonoBehaviour
{
    public Transform[] player;
    private NavMeshAgent nav;
    private int destPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!nav.pathPending && nav.remainingDistance < 0.5)
            GoToPlayer();
    }

    void GoToPlayer()
    {
        if(player.Length == 0)
        {
            return;
        }
        nav.destination = player[destPoint].position;
        destPoint = (destPoint + 1) % player.Length;
    }
}
