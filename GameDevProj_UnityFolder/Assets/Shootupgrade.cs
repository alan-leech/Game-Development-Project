using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shootupgrade : MonoBehaviour {

	public List <Transform> Enemies;
	public Transform NewTarget;
	
	void Start () 
	{
		NewTarget = null;
		Enemies = new List<Transform>();
		AddEnemiesToList();
	}
	
	public void AddEnemiesToList()
	{
		GameObject[] ItemsInList = GameObject.FindGameObjectsWithTag("enemy");
		foreach(GameObject _Enemy in ItemsInList)
			
		{
			AddTarget(_Enemy.transform);
		}
	}
	
	public void AddTarget(Transform enemy)
	{
		Enemies.Add(enemy);
	}
	
	public void DistanceToTarget()
	{
		Enemies.Sort(delegate( Transform t1, Transform t2){ 
			return Vector3.Distance(t1.transform.position,transform.position).CompareTo(Vector3.Distance(t2.transform.position,transform.position)); 
		});
		
	}
	
	public void TargetedEnemy()
	{
		if(NewTarget == null)
		{
			DistanceToTarget();
			NewTarget = Enemies[0];
		}	
	}
	
	void Update () 
	{
		TargetedEnemy();
		float dist = Vector3.Distance(NewTarget.transform.position,transform.position);
		transform.position = Vector3.MoveTowards(transform.position, NewTarget.position, 30 * Time.deltaTime);
		
		
	}

}
