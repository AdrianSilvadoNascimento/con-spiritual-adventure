using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollision : MonoBehaviour
{
    public PlayerBehavior pb;
    //public GameObject particle;

    private void Update()
    {
        if (pb.isAttacking)
        {
            print(pb.isAttacking);

        }

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && pb.isAttacking)
        {
            print("BATEU AQUI");
            Debug.Log(other.name);
            /*Instantiate(particle, new Vector3(other.transform.position.x,
                    transform.position.y,
                    other.transform.position.z), other.transform.rotation);*/
        }
    }
}
