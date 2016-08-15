using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    private Vector3 movement;
    private Animator anim;
    private Rigidbody playerRigidbody;
    private int floorMask;
    private float camRayLength = 100.0f;

    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);
        Turning();
        Animating(h, v);
    }

    void Move(float h, float v)
    {
        movement.Set(h, 0.0f, v);
        movement = movement.normalized * speed * Time.deltaTime;

        playerRigidbody.MovePosition(transform.position + movement);
    }

    void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToPoint = floorHit.point - transform.position;
            playerToPoint.y = 0.0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToPoint);

            playerRigidbody.MoveRotation(newRotation);
        }
    }

    void Animating(float h, float v)
    {
        bool walking = h != 0.0f || v != 0.0f;

        anim.SetBool("IsWalking", walking);
    }
}
