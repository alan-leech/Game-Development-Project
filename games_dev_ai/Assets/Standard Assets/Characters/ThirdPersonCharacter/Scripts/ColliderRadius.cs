using UnityEngine;
using System.Collections;

public class ColliderRadius : MonoBehaviour {


	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {

		CapsuleCollider cylinder = gameObject.GetComponent<CapsuleCollider>();
		cylinder.radius = 1;

		//float startTime;
		//int duration = 2;

		if (Input.GetKey ("up")) {
			cylinder.radius=4;
		}
	
		/*if(cylinder.radius < 7){
			//do{
				//startTime = Time.time;
				for(int x = 1;cylinder.radius <7; x++){
					cylinder.radius = x;
				}
			//}while(Time.time - startTime < duration);
		}

		else if(cylinder.radius == 7){
			//do{	
				//startTime = Time.time;
				for(int y = 7;cylinder.radius > 1; y = y-1){
					cylinder.radius = y;
				}
			//}while(Time.time - startTime < duration);
		}*/


	}
}
