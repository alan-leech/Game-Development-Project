using UnityEngine;
using System.Collections;

[RequireComponent(typeof (NavMeshAgent))]
[RequireComponent(typeof (ThirdPersonCharacter))]
public class GuardChar : MonoBehaviour
{
	public NavMeshAgent agent { get; private set; } // the navmesh agent required for the path finding
	public ThirdPersonCharacter character { get; private set; } // the character we are controlling
	public Transform target; // target to aim for
	
	// Use this for initialization
	private void Start()
	{
		// get the components on the object we need ( should not be null due to require component so no need to check )
		agent = GetComponentInChildren<NavMeshAgent>();
		//character = GetComponent<ThirdPersonCharacter>();
		//character = GameObject.FindWithTag("Guard").GetComponent<ThirdPersonCharacter>();
		character = gameObject.GetComponent<ThirdPersonCharacter>();

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

		}
		
		
		Vector3 fwd = transform.TransformDirection (Vector3.forward); //if player moves infront of guard chase player
		if (Physics.Raycast (transform.position, fwd, 10)) {
			this.target = GameObject.FindWithTag ("Player").transform; 
		}

		
	}
	
	
	public void OnTriggerEnter(Collider col){
		

		
		if(col.gameObject.name == "Cylinder")
		{
			this.target = GameObject.FindWithTag("Player").transform;
		}
		
		else if(col.gameObject.name == "Stone(Clone)")
		{
			this.target = GameObject.FindWithTag("stone").transform;
		}
		
	}
	
	
}//end of class
