using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class SimpleMovementScriptForTesting : MonoBehaviour
{
public float movementSpeed = 3f;
public float jumpSpeed = 500f;
private bool isGrounded = true;
private Rigidbody2D rb;

private void Start()
{
    rb = GetComponent<Rigidbody2D>();
}

void Update()
{
    if (isGrounded)
    {
        rb.gravityScale = 2.1f;
    }

    if (Input.GetKey("a"))
    {
        transform.position += Vector3.left * movementSpeed * Time.deltaTime;

    }
    if (Input.GetKey("d"))
    {
        transform.position += Vector3.right * movementSpeed * Time.deltaTime;
    }
    if (Input.GetKey("s"))
    {
        if (!isGrounded)
        {
            rb.gravityScale += 2;
        }
    }
    if (Input.GetKeyDown(KeyCode.Space))
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpSpeed);
            isGrounded = false;
        }
    }
}

private void OnCollisionEnter2D(Collision2D collision)
{
    isGrounded = true;
}
}