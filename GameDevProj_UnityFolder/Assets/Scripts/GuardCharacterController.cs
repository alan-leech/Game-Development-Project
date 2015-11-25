using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Characters.ThirdPerson
{
	[RequireComponent(typeof (NavMeshAgent))]
	[RequireComponent(typeof (ThirdPersonCharacter))]
	public class GuardCharacterController : MonoBehaviour
		{
			public NavMeshAgent agent { get; private set; } // the navmesh agent required for the path finding
			public ThirdPersonCharacter character { get; private set; } // the character we are controlling
			public Transform target; // target to aim for
			//public GameObject spawn; // initial position
			
			// Use this for initialization
			private void Start()
			{
				// get the components on the object we need ( should not be null due to require component so no need to check )
				agent = GetComponentInChildren<NavMeshAgent>();
				character = GetComponent<ThirdPersonCharacter>();
				
				agent.updateRotation = false;
				agent.updatePosition = true;
				
			}
			
			
			// Update is called once per frame
			private void Update()
			{
				
				if (target != null)
				{
					agent.SetDestination(target.position);
					
					// use the values to move the character
					character.Move(agent.desiredVelocity, false, false);
					
				}
				else
				{
					// We still need to call the character's move function, but we send zeroed input as the move param.
					character.Move(Vector3.zero, false, false);

					this.target = GameObject.FindWithTag("patrol_point_2").transform;
				}
				
				
				Vector3 fwd = transform.TransformDirection (Vector3.forward); //if player moves infront of guard chase player
				if (Physics.Raycast (transform.position, fwd, 15)) {
					this.target = GameObject.FindWithTag ("Player").transform; 
				}

			//var right45 = (transform.forward + transform.right).normalized;
			//var left45 = (transform.forward - transform.right).normalized;

		/*	var right45 = (transform.forward + transform.right)/4;
			var left45 = (transform.forward - transform.right)/4;


			if (Physics.Raycast (transform.position, right45, 30)) {
				this.target = GameObject.FindWithTag ("Player").transform; 
			}

			if (Physics.Raycast (transform.position, left45, 30)) {
				this.target = GameObject.FindWithTag ("Player").transform; 
			}*/


				
			}
			
			
			public void OnTriggerEnter(Collider col){
				
				if(col.gameObject.name == "Patrol_Point_1"){
					this.target = GameObject.FindWithTag("patrol_point_2").transform;
				}
				
				else if(col.gameObject.name == "Patrol_Point_2"){
					this.target = GameObject.FindWithTag("patrol_point_1").transform;
				}
				
				else if(col.gameObject.name == "Cylinder"){
					this.target = GameObject.FindWithTag("Player").transform;
				}
				
				else if(col.gameObject.name == "Stone(Clone)"){
					this.target = GameObject.FindWithTag("stone").transform;
				}
				
			}
			
			
		}
}
