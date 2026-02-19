using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float startPos;
    private float startPosY;
    public GameObject camera;
    public float parallaxEffect;
    
    void Start()
    {
        startPos = transform.position.x;
        startPosY = transform.position.y;
    }


    void FixedUpdate()
    {
        float distance = camera.transform.position.x * parallaxEffect;
        float distanceY = camera.transform.position.y * parallaxEffect;

        transform.position = new Vector3(startPos + distance, startPosY + distanceY, transform.position.z);
    }
}
