using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 10f;
    
    private Animator animator;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update() {
    }

    void FixedUpdate()
    {
        // if (Input.GetAxisRaw("Horizontal") < 0)
        // {
        //     animator.Play("WalkLeft");
        // } else if (Input.GetAxisRaw("Horizontal") > 0)
        // {
        //     animator.Play("WalkRight");
        // } else if (Input.GetAxisRaw("Vertical") < 0)
        // {
        //     animator.Play("WalkDown");
        // } else if (Input.GetAxisRaw("Vertical") > 0)
        // {
        //     animator.Play("WalkUp");
        // } else {
        //     animator.Play("Idle");
        // }

        transform.Translate(Vector3.right * Input.GetAxisRaw("Horizontal") * movementSpeed * Time.deltaTime);
        transform.Translate(Vector3.up * Input.GetAxisRaw("Vertical") * movementSpeed * Time.deltaTime);
        
        animator.SetInteger("horizontalSpeed", (int)Mathf.Abs(Input.GetAxisRaw("Horizontal")));
        animator.SetInteger("verticalSpeed", (int)Mathf.Abs(Input.GetAxisRaw("Vertical")));
        animator.SetFloat("moveX", Input.GetAxisRaw("Horizontal"));
        animator.SetFloat("moveY", Input.GetAxisRaw("Vertical"));
    }
}
