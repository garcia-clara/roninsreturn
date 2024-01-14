using UnityEngine;

public class move : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public bool isJumping;
    public bool isGrounded;
    public bool isTakingDamage;
    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayers;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    private float horizontalMovement;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update(){
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            isJumping = true;
        }

        Flip(rb.velocity.x);
        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);

    }
    void FixedUpdate(){
        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);
        MovePlayer(horizontalMovement);
    }

    void MovePlayer(float _horizontalMovement){
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
    
        if(isJumping == true){
        rb.AddForce(new Vector2(0f, jumpForce));
        animator.SetBool("isJumping", true);
        animator.SetFloat("VerticalSpeed", rb.velocity.y);
        isJumping = false;
    }
    }

    void Flip(float _velocity){
        if (_velocity > 0.1f){
            spriteRenderer.flipX = false;
        } else if(_velocity < -0.1f) {
            spriteRenderer.flipX = true;
        }
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}


