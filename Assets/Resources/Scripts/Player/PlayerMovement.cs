using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float walkSpeed = 6.9f;
    public float sprintSpeed = 9.9f;

    public float acceleration = 5f;
    public float deceleration = 150f;

    public float gravity = -9.81f;
    public float jumpHeight = 1.5f;

    float currentSpeed;
    float velocityY;

    public InventoryManager inventory;

    public bool movement = true;

    public bool isSwimming;

    void Update()
    {
        if (movement)
        {
            float x = (Input.GetKey(KeyCode.D) ? 1 : 0) - (Input.GetKey(KeyCode.A) ? 1 : 0);
            float z = (Input.GetKey(KeyCode.W) ? 1 : 0) - (Input.GetKey(KeyCode.S) ? 1 : 0);

            Vector3 move = transform.right * x + transform.forward * z;

            float targetSpeed;

            if (move.sqrMagnitude < 0.01f)
            {
                targetSpeed = 0f;
            }
            else
            {
                targetSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed;
            }

            float accelRate = (targetSpeed > currentSpeed) ? acceleration : deceleration;

            currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, accelRate * Time.deltaTime);

            if (isSwimming)
            {
                velocityY = 0f;

                if (Input.GetKey(KeyCode.Space))
                    velocityY = walkSpeed;

                if (Input.GetKey(KeyCode.LeftShift))
                    velocityY = -walkSpeed;
            }
            else
            {
                if (controller.isGrounded && velocityY < 0f)
                {
                    velocityY = -2f;
                }

                if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
                {
                    velocityY = Mathf.Sqrt(jumpHeight * -2f * gravity);
                }

                velocityY += gravity * Time.deltaTime;
            }

            Vector3 velocity = move.normalized * currentSpeed;
            velocity.y = velocityY;

            controller.Move(velocity * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.Q))
            {
                inventory.DropItem(0, transform.position + transform.forward * 2f);
            }
        }
    }
}
