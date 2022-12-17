using UnityEngine;

public class Arrow : MonoBehaviour {
    [SerializeField]
    //private float arrowSpeed = 0.5f, gravity = 0.09f;

    public Vector3 m_target;
    public float speed;


    //private float counter = 0;
    //public GameObject arrow;
    
    void Update() {
        float step = speed * Time.deltaTime;
        if (m_target != null) {
            transform.position = Vector3.MoveTowards(transform.position, m_target, step);
        }
        /**
        counter += Time.deltaTime;
        transform.position += Vector3.forward * arrowSpeed * Time.deltaTime;
        transform.position += Vector3.down * gravity * Time.deltaTime;
        if (counter >= 10f) {
            Object.Destroy(arrow);
        }
        */
    }

    public void setTarget(Vector3 target) {
        m_target = target;
    }
}
