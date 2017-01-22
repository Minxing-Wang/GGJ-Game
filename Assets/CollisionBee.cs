using UnityEngine;
using System.Collections;

public class CollisionBee : MonoBehaviour
{

    public GameObject bees;
    private bool once = true;

    void OnCollisionEnter(Collision collision)
    {
        if (once && collision.gameObject.name == "FPSController")
        {
            for (int i = 0; i < 100; i++)
            {
                Instantiate(bees, collision.gameObject.transform.position, new Quaternion());
            }
            once = false;
        }
    }
}