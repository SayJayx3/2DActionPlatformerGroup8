using UnityEngine;

public class BulletCasing : MonoBehaviour
{ 
   
    [SerializeField] float forceAmount;
    private Rigidbody2D playerRB;


    private void Update()
    {
        Debug.Log(playerRB.linearVelocityX);
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
            if(playerRB.linearVelocityX < 0)
            {
                bulletRB.AddForce(transform.right *  forceAmount, ForceMode2D.Impulse);
                Debug.Log("ForceAdded");
            }

            Debug.Log(bulletRB + "BulletDetected");
        }


    }

}
