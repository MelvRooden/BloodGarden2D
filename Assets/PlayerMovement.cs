using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField]
    private bool facingRight = true;

    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Animator animator;

    private Vector2 movement;

    // Update is called once per frame
    private void Update()
    {
        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        // Movement
        if (animator.GetBool("MovementBlocked")) return;

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        float h = Input.GetAxis("Horizontal");
        if (h > 0 && !facingRight || h < 0 && facingRight) Flip();
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0);
    }
}
