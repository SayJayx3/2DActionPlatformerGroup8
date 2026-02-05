using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float fireTimer;
    public GameObject ballPrefab;
    public Transform bulletSpawnPos;
    
    private void Update()
    {

        fireTimer += Time.deltaTime;


        if (fireTimer > 3f)
        {
            Instantiate(ballPrefab, bulletSpawnPos.position, Quaternion.identity);
            fireTimer = 0;
        }
    }
}
