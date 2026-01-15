using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Shooting : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    private float timer;
    private bool reloadNeccesary;

    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    public float timeBetweenFiring;
    public int bulletsInsideCasing;
    public int startingMagazine;

    private void Awake()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        bulletsInsideCasing = startingMagazine;
    }

    private void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (!canFire)
        {
            timer += Time.deltaTime;
            if(timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }

        
        
       if (Input.GetMouseButton(0) && canFire && reloadNeccesary == false)
       {
             canFire = false;
            bulletsInsideCasing -= 1;
             Instantiate(bullet, bulletTransform.position, Quaternion.identity);
       }
        
       if(bulletsInsideCasing <= 0)
        {
            reloadNeccesary = true;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            bulletsInsideCasing = startingMagazine;
            reloadNeccesary = false;
        }
       
        Debug.Log(canFire);
    }
}
