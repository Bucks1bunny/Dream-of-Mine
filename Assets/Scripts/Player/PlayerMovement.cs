using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float startPlayerSpeed = 5f;
    public float jumpHeight = 2f;
    public static float playerSpeed;
    
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float groundCollisionFix = 0.4f;
    public float gravityValue = -9.81f;

    private void Start()
    {
        playerSpeed = startPlayerSpeed;
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = - groundCollisionFix;
        }

        float vectorX = Input.GetAxis("Horizontal");
        float vectorZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * vectorX + transform.forward * vectorZ;

        controller.Move(move * playerSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue - groundCollisionFix);
        }
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
