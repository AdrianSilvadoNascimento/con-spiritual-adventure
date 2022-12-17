using UnityEngine;

public class Movement : MonoBehaviour {
    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private Transform cameraTransform, combatLookAt;

    [SerializeField]
    private GameObject thirdPersonCam, CombatSwordThirdCamera, CombatArchThirdCamera;

    private Animator animator;
    private CharacterController characterController;
    private float ySpeed;
    private float originalStepOffset;
    private bool isArchMode = false;

    public PlayerBehaviour currentBehaviour;
    public enum PlayerBehaviour {
        SwordCombat,
        ArchCombat,
        Relax,
    }

    void Start() {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        originalStepOffset = characterController.stepOffset;
        currentBehaviour = PlayerBehaviour.Relax;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.T)) {
            isArchMode = !isArchMode;
            if (isArchMode) {
                currentBehaviour = PlayerBehaviour.ArchCombat;
                animator.SetBool("isArcherMode", true);
            }

            if (!isArchMode) {
                currentBehaviour = PlayerBehaviour.Relax;
                animator.SetBool("isArcherMode", false);
            }

            SwitchCameraBehavior(currentBehaviour);
        }

        if (isArchMode && Input.GetKey(KeyCode.Mouse0)) {
            animator.SetBool("isAiming", true);
        }

        if (isArchMode && Input.GetKeyUp(KeyCode.Mouse0)) {
            animator.SetBool("isAiming", false);
            animator.SetBool("shoot", true);
        }
        if (currentBehaviour == PlayerBehaviour.Relax) {
            RelaxMove();
        } else if (currentBehaviour == PlayerBehaviour.ArchCombat) {
            ArcherMove();
        }
    }

    // When starts the game and when the player is in relax behaviour
    private void RelaxMove() {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);

        inputMagnitude /= 2;

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
            inputMagnitude *= 2;
        }

        animator.SetFloat("moving", inputMagnitude, 0.05f, Time.deltaTime);

        movementDirection = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * movementDirection;
        movementDirection.Normalize();

        ySpeed += Physics.gravity.y * Time.deltaTime;

        if (movementDirection != Vector3.zero) {
            animator.SetBool("isMoving", true);
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        } else {
            animator.SetBool("isMoving", false);
        }
    }
    
    // When the currentBehaviour is ArchBehaviour
    private void ArcherMove() {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        animator.SetFloat("BowStrafe", horizontalInput);
        animator.SetFloat("BowForward", verticalInput);
        /**
        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);

        inputMagnitude /= 2;

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
            inputMagnitude *= 2;
        }

        animator.SetFloat("moving", inputMagnitude, 0.05f, Time.deltaTime);

        ySpeed += Physics.gravity.y * Time.deltaTime;

        Vector3 inputDir = transform.forward * verticalInput + transform.right * horizontalInput;

        if (movementDirection != Vector3.zero) {
            animator.SetBool("isMoving", true);
            rotationSpeed = 20;
            transform.forward = Vector3.Slerp(transform.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);

            Vector3 dirCombatLookAt = combatLookAt.position - new Vector3(
                transform.position.x,
                combatLookAt.position.y,
                transform.position.z
            );

            dirCombatLookAt.Normalize();
        } else {
            animator.SetBool("isMoving", false);
        }
        */
    }

    private void SwitchCameraBehavior(PlayerBehaviour newBehaviour) {
        thirdPersonCam.SetActive(false);
        CombatSwordThirdCamera.SetActive(false);
        CombatArchThirdCamera.SetActive(false);

        if (newBehaviour == PlayerBehaviour.Relax) thirdPersonCam.SetActive(true);
        if (newBehaviour == PlayerBehaviour.SwordCombat) CombatSwordThirdCamera.SetActive(true);
        if (newBehaviour == PlayerBehaviour.ArchCombat) CombatArchThirdCamera.SetActive(true);

        currentBehaviour = newBehaviour;
    }
}
