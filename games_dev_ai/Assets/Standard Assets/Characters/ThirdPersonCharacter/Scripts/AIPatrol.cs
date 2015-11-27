using UnityEngine;
using System.Collections;

public class AIPatrol : MonoBehaviour
{

    private const float MIN_TIME_BETWEEN_WAYPOINTS = 1;

    public Transform[] waypoints;
    int currentLaypointIX = 0;
    Transform nextWaypoint;
    float wayPointTimer = MIN_TIME_BETWEEN_WAYPOINTS;

    private void Start()
    {
        nextWaypoint = waypoints[0];
    }


    // Update is called once per frame
    void Update()
    {
        UpdateTimers();
    }

    public void OnTriggerEnter(Collider col)
    {
        GameObject colliderSource = col.gameObject;
        switch (colliderSource.tag)
        {
            case "patrol_point":
                {
                    if (wayPointTimer < MIN_TIME_BETWEEN_WAYPOINTS)
                        return;
                    currentLaypointIX = (currentLaypointIX + 1) % waypoints.Length;
                    wayPointTimer = 0;
                    nextWaypoint = waypoints[currentLaypointIX];
                }
                break;

        }

    }

    void UpdateTimers()
    {
        wayPointTimer += Time.deltaTime;
    }

    public Transform getNextWaypoint()
    {
        return nextWaypoint;
    }


    /*public Vector3 pointB;
	
	IEnumerator Start()
	{
		var pointA = transform.position;
		while (true) {
			yield return StartCoroutine(MoveObject(transform, pointA, pointB, 3.0f));
			yield return StartCoroutine(MoveObject(transform, pointB, pointA, 3.0f));
		}
	}
	
	IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
	{
		var i= 0.0f;
		var rate= 1.0f/time;
		while (i < 1.0f) {
			i += Time.deltaTime * rate;
			thisTransform.position = Vector3.Lerp(startPos, endPos, i);
			yield return null; 
		}
	}*/

}
