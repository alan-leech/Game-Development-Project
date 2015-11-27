using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(ThirdPersonCharacter))]
    public class AICharacterControl : MonoBehaviour
    {
        private const float MIN_INVESTIGATION_DIST = 2;

        public float walkSpeed = 5;
        public float runSpeed = 10;
        public NavMeshAgent agent { get; private set; } // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        AIVision vision;
        AISence sence;
        AIPatrol patrol;
        //public GameObject spawn; // initial position



        Vector3 investigationPoint = Vector3.zero;
        Vector3 lastInspectedPoint = Vector3.zero;


        // Use this for initialization
        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();
            vision = GetComponent<AIVision>();
            sence = GetComponent<AISence>();
            patrol = GetComponent<AIPatrol>();

            agent.updateRotation = false;
            agent.updatePosition = true;
        }


        // Update is called once per frame
        private void Update()
        {

            if (vision.DoISeeSomethingInFrontOfMe())
            {
                if (vision.GetNoticedObject().tag != "Guard")
                    Stop();
            }
            else if (DoINeedToInvestigate())
            {
                GoTo(investigationPoint, runSpeed);
            }
            else
            {
                GoTo(patrol.getNextWaypoint().position, walkSpeed);
            }


        }

        bool DoINeedToInvestigate()
        {
            investigationPoint = sence.GetSoundLocationToInvestigate();
            if (investigationPoint != Vector3.zero)
            {
                float distanceToInvestigation = Vector3.Distance(investigationPoint, transform.position);
                //print(distanceToInvestigation);
                if (distanceToInvestigation > MIN_INVESTIGATION_DIST)
                {
                    return (lastInspectedPoint != investigationPoint);
                }
                else
                {
                    lastInspectedPoint = investigationPoint;
                }

            }

            return false;
        }


        void GoTo(Vector3 position, float speed)
        {
            agent.SetDestination(position);
            agent.Resume();
            agent.speed = speed;
            character.Move(agent.desiredVelocity, false, false);
        }

        void Stop()
        {
            character.Move(Vector3.zero, false, false);
            agent.Stop();
        }









    }
}
