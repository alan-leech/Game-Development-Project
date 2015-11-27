using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class AISence : MonoBehaviour
{


    Vector3 lastHeardSound = Vector3.zero;
    IList<GameObject> soundSources = new List<GameObject>();

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider col)
    {
        GameObject colliderSource = col.gameObject;
        switch (colliderSource.tag)
        {
            case "sound":
                {
                    soundSources.Add(colliderSource);
                }
                break;
        }
    }

    public void OnTriggerExit(Collider col)
    {
        GameObject colliderSource = col.gameObject;
        switch (colliderSource.tag)
        {
            case "sound":
                {
                    soundSources.Remove(colliderSource);
                    if (soundSources.Count == 0)
                        lastHeardSound = colliderSource.transform.position;
                }
                break;
        }
    }

    public Vector3 GetSoundLocationToInvestigate()
    {
        Vector3 investigationPoint = (soundSources.Count > 0)
            ? soundSources.First().transform.position
            : lastHeardSound;

        return investigationPoint;
    }

}
