using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour {

    public Transform orientation, player, playerObj, combatLookAt;
    public Rigidbody rb;
    public GameObject thirdCamera, combatCamera;

    public Movement move;

    public float rotationSpeed;

    public CameraStyle currentStyle;
    public enum CameraStyle {
        Basic,
        Combat,
    }

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update() {
        // Switch camera view
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            SwitchCamera(CameraStyle.Combat);
        }
        if (Input.GetKeyDown(KeyCode.Q)) {
            SwitchCamera(CameraStyle.Basic);
        }

        // rotate orientation
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;

        // rotate player object
        if (currentStyle == CameraStyle.Basic) {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

            if (inputDir != Vector3.zero)
                playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
        } else if (currentStyle == CameraStyle.Combat) {
            Vector3 dirCombatLookAt = combatLookAt.position - new Vector3(transform.position.x, combatLookAt.position.y, transform.position.z);
            orientation.forward = dirCombatLookAt.normalized;

            playerObj.forward = dirCombatLookAt.normalized;
        }
    }

    void SwitchCamera(CameraStyle newStyle) {
        combatCamera.SetActive(false);
        thirdCamera.SetActive(false);

        if (newStyle == CameraStyle.Basic) thirdCamera.SetActive(true);
        if (newStyle == CameraStyle.Combat) combatCamera.SetActive(true);

        currentStyle = newStyle;
    }
}
