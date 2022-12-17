using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour {
    [SerializeField]
    private float damage = 10f,
                  range = 100f,
                  impactForce = 30f,
                  fireRate = 15f,
                  arrowSpeed = 10f;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private GameObject arrowPrefab;

    [SerializeField]
    private Transform bowSpawnPoint;

    private float nextFire = 0f;
    // public ParticleSystem shootEffect;
    // public GameObject impactEffect;
    
    void Update() {
        if (Input.GetButton("Fire1") && Time.time >= nextFire) {
            nextFire = Time.time + 1f / fireRate;
            Shoot();
            Debug.Log("Atirou");
        }
    }

    void Shoot() {
        // shootEffect.Play();

        var arrow = Instantiate(arrowPrefab, bowSpawnPoint.position, bowSpawnPoint.rotation);
        arrow.GetComponent<Rigidbody>().velocity = bowSpawnPoint.forward * arrowSpeed;
        RaycastHit hitInfo;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hitInfo, range)) {
            Debug.Log(hitInfo.transform.name);

            Target target = hitInfo.transform.GetComponent<Target>();
            if (target != null) {
                target.TakeDamage(damage);
            }
            if (hitInfo.rigidbody != null) {
                hitInfo.rigidbody.AddForce(-hitInfo.normal * impactForce);
            }

            // GameObject impactGameObject = Instantiate(impactEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            // Destroy(impactGameObject, 2f);
        }
    }
}
