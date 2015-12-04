using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shootupgrade : MonoBehaviour {

	public List <Transform> Enemies;
	public Transform NewTarget;
	private PlayerBehaviour playerInfo;
	
	void Start () 
	{
		playerInfo = GameObject.FindWithTag("Player").GetComponent<PlayerBehaviour>();

		if (playerInfo.GetGunUpgrade () == true) {
			NewTarget = null;
			Enemies = new List<Transform> ();
			AddEnemiesToList ();
		}
	}
	
	public void AddEnemiesToList()
	{
		if (playerInfo.GetGunUpgrade () == true) {
			GameObject[] ItemsInList = GameObject.FindGameObjectsWithTag ("Guard");
			foreach (GameObject _Enemy in ItemsInList) {
				AddTarget (_Enemy.transform);
			}
		}
	}
	
	public void AddTarget(Transform enemy)
	{
		if (playerInfo.GetGunUpgrade () == true) {
			Enemies.Add (enemy);
		}
	}
	
	public void DistanceToTarget()
	{
		if (playerInfo.GetGunUpgrade () == true) {
			Enemies.Sort (delegate( Transform t1, Transform t2) { 
				return Vector3.Distance (t1.transform.position, transform.position).CompareTo (Vector3.Distance (t2.transform.position, transform.position)); 
			});
		}
	}
	
	public void TargetedEnemy()
	{
		if (playerInfo.GetGunUpgrade () == true) {
			if (NewTarget == null) {
				DistanceToTarget ();
				NewTarget = Enemies [0];
			}	
		}
	}
	
	void Update () 
	{
		if (playerInfo.GetGunUpgrade () == true) {
			TargetedEnemy ();
			float dist = Vector3.Distance (NewTarget.transform.position, transform.position);
			transform.position = Vector3.MoveTowards (transform.position, NewTarget.position, 30 * Time.deltaTime);
		}
		
		
	}

}
