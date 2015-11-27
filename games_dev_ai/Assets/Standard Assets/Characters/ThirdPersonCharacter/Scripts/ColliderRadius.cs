using UnityEngine;
using System.Collections;

public class ColliderRadius : MonoBehaviour
{
    CapsuleCollider cylinder;

    // Use this for initialization
    void Start()
    {
        cylinder = gameObject.GetComponent<CapsuleCollider>();

    }

    // Update is called once per frame
    void Update()
    {


        cylinder.radius = 1;

        //float startTime;
        //int duration = 2;

        if (Input.GetKey("up"))
        {
            cylinder.radius = 10;
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
