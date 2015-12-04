using UnityEngine;
using System.Collections;

public class DestroyEnemies : MonoBehaviour {

	public object Guard;

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag =="Guard")
		{
			Destroy(col.gameObject);
		}
	}
	

}
