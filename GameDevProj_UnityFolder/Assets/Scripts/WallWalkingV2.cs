﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class WallWalkingV2 : MonoBehaviour {
	
	public float moveSpeed = 6; // move speed
	public float turnSpeed = 90; // turning speed (degrees/second)
	public float lerpSpeed = 10; // smoothing speed
	public float gravity = 10; // gravity acceleration
	private bool isGrounded;
	private float deltaGround = 0.2f; // character is grounded up to this distance
	public float jumpSpeed = 10; // vertical jump initial speed
	public float jumpRange = 10; // range to detect target wall
	private Vector3 surfaceNormal; // current surface normal
	private Vector3 myNormal; // character normal
	private float distGround; // distance from character position to ground
	private bool jumping = false; // flag &quot;I'm jumping to wall&quot;
	private float vertSpeed = 0; // vertical jump current speed
	
	private Transform myTransform;
	public BoxCollider boxCollider;
	
	private void Start(){
		myNormal = transform.up; // normal starts as character up direction
		myTransform = transform;
		GetComponent<Rigidbody>().freezeRotation = true; // disable physics rotation
		// distance from transform.position to ground
		distGround = boxCollider.extents.y - boxCollider.center.y;
		
	}
	
	private void FixedUpdate(){
		// apply constant weight force according to character normal:
		GetComponent<Rigidbody>().AddForce(-gravity*GetComponent<Rigidbody>().mass*myNormal);
	}
	
	private void Update(){
		// jump code - jump to wall or simple jump
		if (jumping) return; // abort Update while jumping to a wall

		Ray ray;
		RaycastHit hit;

		if (Input.GetButtonDown("Jump")){ // jump pressed:
			ray = new Ray(myTransform.position, myTransform.forward );
			if (Physics.Raycast(ray, out hit, jumpRange) && hit.collider.gameObject.CompareTag("MetalWall")){ // wall ahead?
				JumpToWall(hit.point, hit.normal); // yes: jump to the wall
			}
			else if (isGrounded){ // no: if grounded, jump up
				GetComponent<Rigidbody>().velocity += jumpSpeed * myNormal;
			}
		}
		
		// movement code - turn left/right with Horizontal axis:
		myTransform.Rotate(0, Input.GetAxis("Horizontal")*turnSpeed*Time.deltaTime, 0);
		// update surface normal and isGrounded:
		ray = new Ray(myTransform.position, -myNormal); // cast ray downwards

		//Checks to see if there is a collider within the raycast.
		if (Physics.Raycast (ray, out hit)) { // use it to update myNormal and isGrounded
			isGrounded = hit.distance <= distGround + deltaGround;
			surfaceNormal = hit.normal;
		
			//If B is pressed (held) Orientation is reset to downward on the Y axis.
			if (Input.GetKey (KeyCode.B)) 
				surfaceNormal = Vector3.up;
		} else {
			if (Input.GetKey (KeyCode.B)) 
				surfaceNormal = Vector3.up;
		}

	
		myNormal = Vector3.Lerp(myNormal, surfaceNormal, lerpSpeed*Time.deltaTime);
		// find forward direction with new myNormal:
		Vector3 myForward = Vector3.Cross(myTransform.right, myNormal);
		// align character to the new myNormal while keeping the forward direction:
		Quaternion targetRot = Quaternion.LookRotation(myForward, myNormal);
		myTransform.rotation = Quaternion.Lerp(myTransform.rotation, targetRot, lerpSpeed*Time.deltaTime);
		// move the character forth/back with Vertical axis:
		myTransform.Translate(0, 0, Input.GetAxis("Vertical")*moveSpeed*Time.deltaTime);
	}
	
	private void JumpToWall(Vector3 point, Vector3 normal){
		// jump to wall
		jumping = true; // signal it's jumping to wall
		GetComponent<Rigidbody>().isKinematic = true; // disable physics while jumping
		Vector3 orgPos = myTransform.position;
		Quaternion orgRot = myTransform.rotation;
		Vector3 dstPos = point + normal * (distGround + 0.5f); // will jump to 0.5 above wall
		Vector3 myForward = Vector3.Cross(myTransform.right, normal);
		Quaternion dstRot = Quaternion.LookRotation(myForward, normal);
		
		StartCoroutine (jumpTime (orgPos, orgRot, dstPos, dstRot, normal));
		//jumptime
	}
	
	private IEnumerator jumpTime(Vector3 orgPos, Quaternion orgRot, Vector3 dstPos, Quaternion dstRot, Vector3 normal) {
		for (float t = 0.0f; t < 1.0f; ){
			t += Time.deltaTime;
			myTransform.position = Vector3.Lerp(orgPos, dstPos, t);
			myTransform.rotation = Quaternion.Slerp(orgRot, dstRot, t);
			yield return null; // return here next frame
		}
		myNormal = normal; // update myNormal
		GetComponent<Rigidbody>().isKinematic = false; // enable physics
		jumping = false; // jumping to wall finished
		
	}
	
}