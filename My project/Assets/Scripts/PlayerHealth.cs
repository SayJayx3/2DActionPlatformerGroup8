using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int health;
    private SceneLoader sceneLoader;
    public TextMeshProUGUI healthText;

    private void Awake()
    {
        sceneLoader = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneLoader>();
        health = maxHealth;
    }

    private void Update()
    {
        healthText.text = "Health:" + health.ToString();
        if (health <= 0)
        {
            sceneLoader.SceneLoadLoseScene();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            health -= 1;
        }
    }


}
