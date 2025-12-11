using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform spawnPos;
    public GameObject bulletPrefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            SpawnBullet();
        }
    }


    private void SpawnBullet()
    {
        Instantiate(bulletPrefab, spawnPos.position, spawnPos.rotation);
    }
}
