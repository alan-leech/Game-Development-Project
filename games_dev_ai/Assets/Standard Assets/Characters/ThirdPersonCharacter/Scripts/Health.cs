using UnityEngine;

public class Health : MonoBehaviour
{

    public float health = 1f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void takeHealth(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(transform.gameObject);
        }

    }
}
