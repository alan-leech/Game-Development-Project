using UnityEngine;
using System.Collections;

public class Destroyaftertime : MonoBehaviour {

	public float lifetime = 2;
	void Awake()
	{
		Destroy (gameObject, lifetime);
	}
}
