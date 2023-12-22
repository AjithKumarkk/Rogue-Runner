using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float moveSpeed = 4f;
    private float jumpForce = 6f;
    private Rigidbody2D playerRb;
    private Collider2D playerCollider;
    private bool isGrounded;
    private bool isFacingRight = true;
    private float horizontalInput;
    private Animator animator;
    private PlayerManager playerManager;
    public ParticleSystem playerParticleSystem;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        playerManager = FindObjectOfType<PlayerManager>();
        Physics2D.IgnoreLayerCollision(7, 8, false);
    }

    void Update()
    {
        isGrounded = IsGrounded();

        horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput, 0);
        playerRb.velocity = new Vector2(movement.x * moveSpeed, playerRb.velocity.y);

        float clampedX = Mathf.Clamp(transform.position.x, -13f, float.MaxValue);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);

        if ((horizontalInput > 0 && !isFacingRight) || (horizontalInput < 0 && isFacingRight))
        {
            Flip();
        }
        if (isGrounded)
        {
            animator.SetBool("IsJumping", false);

            if (Mathf.Abs(horizontalInput) > 0)
            {
                animator.SetBool("IsRunning", Mathf.Abs(horizontalInput) > 0);
            }
            else
            {
                animator.SetBool("IsRunning", false);

            }
        }

        if (isGrounded && Input.GetKeyDown(KeyCode.UpArrow))
        {
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            StartCoroutine(PlayJumpAnimation());
        }
    }

    IEnumerator PlayJumpAnimation()
    {
        animator.SetBool("IsJumping", true);
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("IsJumping", false);
    }

    private bool IsGrounded()
    {
        float raycastLength = 0.5f;

        // Use the circle collider's center as the raycast origin
        Vector2 raycastOrigin = new Vector2(playerCollider.bounds.center.x, playerCollider.bounds.center.y - playerCollider.bounds.extents.y);

        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, Vector2.down, raycastLength, LayerMask.GetMask("Ground")); ;

        return hit.collider != null;
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Door"))
        {
            // Activate the particle system when colliding with the door
            if (playerParticleSystem != null)
            {
                playerParticleSystem.Play();
                playerManager.FinishGame();
                gameObject.SetActive(false);
            }

            
        }

    }
}
