using UnityEngine;
using UnityEngine.ParticleSystemJobs;
public class Bullet : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;
    public bool collisionDetected;
    private ParticleSystem particleUsage;
    private ParticleSystem theInstParticle;
    private float destroyThisObject;

    void Start()
    {

        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);

        ParticleSystem particle = GameObject.FindGameObjectWithTag("BulletParticle").GetComponent<ParticleSystem>();
        particleUsage = particle;
    }

    private void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collisionDetected = true;
        theInstParticle = Instantiate(particleUsage, transform.position, transform.rotation);
        
        theInstParticle.Play();

        Destroy(this.gameObject);
    }
}
