using UnityEngine;
using System.Collections;

public class shoot : MonoBehaviour {

	public Rigidbody projectile;
	public float speed = 20;
	public GameObject bullet;
	public float time = 1000;


	void Update(){
		if(Input.GetButton("Fire1")){

			Rigidbody instantiatedProjectile = Instantiate(projectile,transform.position,transform.rotation)as Rigidbody;
			instantiatedProjectile.velocity = transform.TransformDirection (new Vector3(0 ,0,speed));
		

		}

	}

}


	
	
	
