using UnityEngine;
using System.Collections;

public class Destroyaftertime : MonoBehaviour {

	public float lifetime =1 ;
	void Awake()
	{
		Destroy(gameObject, lifetime);
	}
}
