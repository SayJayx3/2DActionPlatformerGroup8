using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float fireTimer;
    public GameObject ballPrefab;
    public Transform bulletSpawnPos;
    public int Health;
    public int MaxHealth;

    private void Awake()
    {
        Health = MaxHealth;
    }

    private void Update()
    {
        Death();
        Debug.Log(Health);
        fireTimer += Time.deltaTime;


        if (fireTimer > 3f)
        {
            Instantiate(ballPrefab, bulletSpawnPos.position, Quaternion.identity);
            fireTimer = 0;
        }
    }

    private void Death()
    {
        if(Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Health -= 1;
        }
    }
}
