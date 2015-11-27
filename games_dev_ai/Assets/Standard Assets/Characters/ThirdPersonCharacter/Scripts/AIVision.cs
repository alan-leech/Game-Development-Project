using UnityEngine;
using System.Collections;

public class AIVision : MonoBehaviour
{

    public int viewDistance = 15;

    GameObject noticedObject;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool DoISeeSomethingInFrontOfMe()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        bool result = Physics.Raycast(transform.position, fwd, out hit, viewDistance);
        noticedObject = (result) ? hit.collider.gameObject : null;

        return result;


    }

    public GameObject GetNoticedObject()
    {
        return noticedObject;
    }

}
