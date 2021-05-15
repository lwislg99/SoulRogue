using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class aiMovement : MonoBehaviour
{
    [SerializeField] Transform target1;
    [SerializeField] Transform target2;
    [SerializeField] Transform Player;
    NavMeshAgent agent;

    public float target1Dist;
    public float target2Dist;
    public float playerDist;
    bool ida;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        ida = false;
    }

    // Update is called once per frame
    void Update()
    {

        target1Dist = Vector2.Distance(target1.transform.position, transform.position);
        target2Dist = Vector2.Distance(target2.transform.position, transform.position);
        playerDist = Vector2.Distance(Player.transform.position, transform.position);

        if (playerDist <=5)
        {
            agent.SetDestination(Player.position);
        }
        else
        {
        
        if (ida==false)
            {
                agent.SetDestination(target1.position);
                if(target1Dist <=1)
                {
                    ida = true;
                }
            }
            if (ida == true)
            {
                agent.SetDestination(target2.position);
                if (target2Dist <= 1)
                {
                    ida = false;
                }
            }
        }

    }
}
