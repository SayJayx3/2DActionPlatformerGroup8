using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;

public class Shooting : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    private float timer;
    private bool reloadNeccesary;
    private float reloadTimer;


    public GameObject bulletCasing;
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    public float timeBetweenFiring;
    public int bulletsInsideMagazine;
    public int startingMagazine;
    [SerializeField] TextMeshProUGUI bulletText;

    private void Awake()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        bulletsInsideMagazine = startingMagazine;
    }

    private void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        bulletText.text = "Mag;" + bulletsInsideMagazine.ToString();

        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }



        if (Input.GetMouseButton(0) && canFire && reloadNeccesary == false)
        {
            canFire = false;
            bulletsInsideMagazine -= 1;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
            Instantiate(bulletCasing, bulletTransform.position, Quaternion.identity);
        }

        if (bulletsInsideMagazine <= 0)
        {
            reloadNeccesary = true;
        }

        if (Input.GetKeyDown(KeyCode.R) && reloadTimer > 3f)
        {
            bulletsInsideMagazine = startingMagazine;
            reloadNeccesary = false;
            reloadTimer = 0;
        }

        reloadTimer += Time.deltaTime;
    }




}
