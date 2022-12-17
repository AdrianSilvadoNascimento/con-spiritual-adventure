using UnityEngine;

public class ArrowShooting : MonoBehaviour {
    public GameObject arrowPrefab;
    public Transform arrowSpawnPosition;
    RaycastHit hit;
    float range = 1000f;

    public void Shoot() {
        Vector2 screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Debug.Log(screenCenter);
        Ray ray = Camera.main.ScreenPointToRay(screenCenter);
        if (Physics.Raycast(ray, out hit, range)) {
            GameObject arrowIsntatiate = Instantiate(arrowPrefab, arrowSpawnPosition.transform.position, arrowSpawnPosition.transform.rotation) as GameObject;
            arrowIsntatiate.GetComponent<Arrow>().setTarget(hit.point);
        }
    }
}
