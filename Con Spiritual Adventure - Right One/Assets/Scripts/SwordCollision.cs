using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollision : MonoBehaviour
{
    public PlayerBehavior pb;
    public BoxCollider sword;
    //public GameObject particle;

    private void Start()
    {
        sword = GetComponent<BoxCollider>();
        sword.isTrigger = false;
    }
    private void Update()
    {
        if (pb.isAttacking)
        {
            sword.isTrigger = true;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Chegou na function");
        Debug.Log(other.tag);
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("BATEU AQUI");
            Debug.Log(other.name);
            StartCoroutine(ResetTrigger());
            /*Instantiate(particle, new Vector3(other.transform.position.x,
                    transform.position.y,
                    other.transform.position.z), other.transform.rotation);*/
        }
    }

    IEnumerator ResetTrigger()
    {
        yield return new WaitForSeconds(0.5f);
        sword.isTrigger = false;
    }
}
