using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(ThirdPersonCharacter))]
    public class AICharacterControl : MonoBehaviour
    {
        private const float MIN_TIME_BETWEEN_WAYPOINTS = 1;
        private const float MIN_INVESTIGATION_DIST = 2;

        public float walkSpeed = 5;
        public float runSpeed = 10;
        public int viewDistance = 15;
        public NavMeshAgent agent { get; private set; } // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        //public GameObject spawn; // initial position
        public Transform[] waypoints;

        int currentLaypointIX = 0;
        Transform nextWaypoint;
        float wayPointTimer = MIN_TIME_BETWEEN_WAYPOINTS;

        GameObject noticedObject;
        Vector3 lastHeardSound = Vector3.zero;
        IList<GameObject> soundSources = new List<GameObject>();
        Vector3 investigationPoint = Vector3.zero;


        // Use this for initialization
        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();

            agent.updateRotation = false;
            agent.updatePosition = true;

            nextWaypoint = waypoints[0];

        }


        // Update is called once per frame
        private void Update()
        {
            UpdateTimers();

            if (DoISeeSomethingInFrontOfMe())
            {
                if (noticedObject.tag != "Guard")
                    Stop();
            }
            else if (DoINeedToInvestigate())
            {
                GoTo(investigationPoint, runSpeed);
            }
            else
            {
                GoTo(nextWaypoint.position, walkSpeed);
            }


        }

        bool DoINeedToInvestigate()
        {
            if (soundSources.Count > 0)
            {
                investigationPoint = soundSources.First().transform.position;
                return true;
            }
            if (lastHeardSound != Vector3.zero)
            {
                float distanceToInvestigation = Vector3.Distance(lastHeardSound, transform.position);
                //print(distanceToInvestigation);
                if (distanceToInvestigation > MIN_INVESTIGATION_DIST)
                {
                    investigationPoint = lastHeardSound;
                    return true;
                }
                else
                {
                    lastHeardSound = Vector3.zero;
                }
            }

            return false;
        }

        void UpdateTimers()
        {
            wayPointTimer += Time.deltaTime;
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

        public bool DoISeeSomethingInFrontOfMe()
        {
            Vector3 fwd = transform.TransformDirection(Vector3.forward); //if player moves infront of guard chase player

            RaycastHit hit;
            bool result = Physics.Raycast(transform.position, fwd, out hit, viewDistance);
            if (result)
            {
                noticedObject = hit.collider.gameObject;
            }

            return result;


        }

        public void OnTriggerEnter(Collider col)
        {
            GameObject colliderSource = col.gameObject;
            switch (colliderSource.tag)
            {
                case "patrol_point":
                    {
                        if (wayPointTimer < MIN_TIME_BETWEEN_WAYPOINTS)
                            return;
                        currentLaypointIX = (currentLaypointIX + 1) % waypoints.Length;
                        wayPointTimer = 0;
                        nextWaypoint = waypoints[currentLaypointIX];
                    }
                    break;
                case "sound":
                    {
                        soundSources.Add(colliderSource);
                    }
                    break;

            }

        }

        public void OnTriggerExit(Collider col)
        {
            GameObject colliderSource = col.gameObject;
            switch (colliderSource.tag)
            {
                case "sound":
                    {
                        soundSources.Remove(colliderSource);
                        if (soundSources.Count == 0)
                            lastHeardSound = colliderSource.transform.position;
                    }
                    break;
            }
        }



    }
}
