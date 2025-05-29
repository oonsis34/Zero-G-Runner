using UnityEngine;

public class SideScrollRun : MonoBehaviour
{
    public float moveSpeed = 5f;        
    public Transform groundLow;        
    public Transform groundHigh;       
    private bool isOnLowGround = true; 

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleGround();
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ToggleGround();
        }
    }

    void ToggleGround()
    {
        
        isOnLowGround = !isOnLowGround;

        if (isOnLowGround)
        {
            
            rb.MovePosition(new Vector2(transform.position.x, groundLow.position.y));

            
            rb.gravityScale = 1;

            
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            
            rb.MovePosition(new Vector2(transform.position.x, groundHigh.position.y));

            
            rb.gravityScale = -1;

            
            transform.rotation = Quaternion.Euler(180, 0, 0);
        }
    }
}