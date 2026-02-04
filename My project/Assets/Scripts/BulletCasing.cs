using UnityEngine;

public class BulletCasing : MonoBehaviour
{ 
   
    [SerializeField] float forceAmount;
    private Rigidbody2D playerRB;
    public bool isMoving;

    private void Update()
    {
        Debug.Log(playerRB.linearVelocityX);

        if(playerRB.linearVelocityX < 0 || playerRB.linearVelocityX > 0)
        {
            isMoving = true;
        }

        else
        {
            isMoving = false;
        }
    }

    private void Awake()
    {
        playerRB = GetComponentInParent<Rigidbody2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BulletCasing"))
        {
            Rigidbody2D bulletRB = collision.GetComponent<Rigidbody2D>();
            if (isMoving == true)
            {
                bulletRB.AddForce(transform.right * forceAmount, ForceMode2D.Impulse);
                Debug.Log("ForceAdded");
            }

            Debug.Log(bulletRB + "BulletDetected");
        }
    }
}
