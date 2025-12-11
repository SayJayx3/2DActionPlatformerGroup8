using UnityEngine;
using System.Collections;
public class BulletScript : MonoBehaviour
{
    public float bulletSpeed;
    public float timeBeforeExpiring;
    Rigidbody2D rb2D;

    GameObject player;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb2D.linearVelocity = transform.right * player.transform.localScale.x * bulletSpeed;
    }

    private void Update()
    {
        timeBeforeExpiring += Time.deltaTime;

        if(timeBeforeExpiring > 10f)
        {
            Destroy(this.gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }
    }
}
