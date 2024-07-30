using UnityEngine;
public class ThirdPersonCont : MonoBehaviour
{
    Animator myAnimator;
    CharacterController controller;
    [SerializeField] float speed;
    [SerializeField] float turnSmoothTime;
    float turnSmoothVelocity;
    [SerializeField] Transform cam;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] float jumpHeight = 3f;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistance=0.4f;
    [SerializeField] LayerMask groundMask;
    Vector3 velocity, direction;
    bool isGrounded;
    private void Start()
    {
        myAnimator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        isGrounded=Physics.CheckSphere(groundCheck.position,groundDistance,groundMask);
        if (isGrounded&& velocity.y<0)
        {
            velocity.y = -2f;
        }
        if (Input.GetButtonDown("Jump")&& isGrounded)
        {
            myAnimator.SetTrigger("Jump");
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        if (!isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        controller.Move(velocity* Time.deltaTime);
        PlayerMovement();
    }
    private void PlayerMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        direction = new Vector3(horizontal,0f, vertical).normalized;
        if (direction.magnitude >= 0.1f && isGrounded)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0, angle, 0);
            Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        myAnimator.SetFloat("Speed", direction.magnitude);
    }
}
