using UnityEngine;
using UnityEngine.InputSystem.Utilities;

public class EnemyBullet : MonoBehaviour
{

    private Vector3 playerPosition;
    private Rigidbody2D rb;
    private GameObject playerTransform;
    [SerializeField] float force;
    private float deleteTimer;




    private void Awake()
    {

        playerTransform = GameObject.FindGameObjectWithTag("Player");

        rb = GetComponent<Rigidbody2D>();
        playerPosition = playerTransform.transform.position;
        Vector3 direction = playerPosition - transform.position;
        Vector3 rotation = transform.position - playerPosition;
        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }


    private void Update()
    {
        deleteTimer += Time.deltaTime;

        if (deleteTimer > 4f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
