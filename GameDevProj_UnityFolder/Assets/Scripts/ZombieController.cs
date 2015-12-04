using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(ThirdPersonCharacter))]
public class ZombieController : MonoBehaviour {

    public NavMeshAgent agent { get; private set; } // the navmesh agent required for the path finding
    public ThirdPersonCharacter character { get; private set; } // the character we are controlling
    public Transform target; // target to aim for

    Vector3 finalPosition;
    Vector3 randomDirection;
    int walkRadius = 100;
    NavMeshHit hit;

    // Use this for initialization
    void Start () {

        // get the components on the object we need ( should not be null due to require component so no need to check )
        agent = GetComponentInChildren<NavMeshAgent>();
        character = GetComponent<ThirdPersonCharacter>();

    agent.updateRotation = false;
        agent.updatePosition = true;

    }
	
	// Update is called once per frame
	void Update () {

        Vector3 fwd = transform.TransformDirection(Vector3.forward); //if player moves infront of guard chase player
        if (Physics.Raycast(transform.position, fwd, 10))
        {
            this.target = GameObject.FindWithTag("Player").transform;

            agent.SetDestination(target.position);

            character.Move(agent.desiredVelocity, false, false);
        }

        if (target == null)
        {
            agent.SetDestination(randomDirection);

            character.Move(agent.desiredVelocity, false, false);

            randomDirection = UnityEngine.Random.insideUnitSphere * walkRadius;
            randomDirection += transform.position;
            NavMesh.SamplePosition(randomDirection, out hit, walkRadius, 1);
            finalPosition = hit.position;
        }

        /* if (finalPosition == randomDirection)
         {
             randomDirection = UnityEngine.Random.insideUnitSphere * walkRadius;
             randomDirection += transform.position;
             NavMesh.SamplePosition(randomDirection, out hit, walkRadius, 1);
             finalPosition = hit.position;


         }*/



        //int changeDestination = 10;

        // do
        // {

        //   System.Random random = new System.Random();

        //    changeDestination = random.Next(0, 1000);

        //} while (changeDestination != 10);

        else
        {
            // We still need to call the character's move function, but we send zeroed input as the move param.
            character.Move(Vector3.zero, false, false);

        }




    }
}
