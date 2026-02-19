using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using Unity.Cinemachine;

public class Shooting : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    private float timer;
    private bool reloadNeccesary;
    private float reloadTimer;
    private bool reloading;
    private bool isFiring;
    private int randomNumber;

    [SerializeField] Animator smokeEffect;
    public float amoutOfTimeNeccesaryToReload;
    public GameObject bulletCasing;
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    public float timeBetweenFiring;
    public int bulletsInsideMagazine;
    public int startingMagazine;
    [SerializeField] TextMeshProUGUI bulletText;
    Animator animator;
    Animator cameraShakeAnimation;


    private void Awake()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        cameraShakeAnimation = GameObject.FindGameObjectWithTag("CinemachineCamera").GetComponent<Animator>();
        animator = GetComponentInChildren<Animator>();
        bulletsInsideMagazine = startingMagazine;
    }

    private void Update()
    {
        Shoot();
        randomNumber = Random.Range(-10, 5);
    }

    void Shoot()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        bulletText.text = ":" + bulletsInsideMagazine.ToString();

        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }


        if (Input.GetMouseButton(0) && canFire && reloadNeccesary == false && reloading == false)
        {
            canFire = false;
            isFiring = true;
            bulletsInsideMagazine -= 1;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
            

            var bulletCasingInstantiation = Instantiate(bulletCasing, bulletTransform.position, Quaternion.identity);
           Rigidbody2D bulletCasingRigidbody2d = bulletCasingInstantiation.GetComponent<Rigidbody2D>();
            bulletCasingRigidbody2d.AddForce(transform.up * randomNumber, ForceMode2D.Impulse);
            bulletCasingRigidbody2d.AddForce(transform.right * randomNumber, ForceMode2D.Impulse);

            cameraShakeAnimation.Play("CameraShake");
            smokeEffect.Play("SmokeAnimation");
            animator.Play("muzzleflash");
        }

        else if (Input.GetMouseButtonUp(0))
        {
            animator.Play("New State");
            smokeEffect.Play("SmokeAnimation");
            cameraShakeAnimation.Play("New State");
            isFiring = false;
        }

        if (bulletsInsideMagazine <= 0)
        {
            reloadNeccesary = true;
            canFire = false;
            animator.Play("New State");
            cameraShakeAnimation.Play("New State");
            smokeEffect.Play("New State");
        }

        if (Input.GetKeyDown(KeyCode.R) && reloadTimer > amoutOfTimeNeccesaryToReload && isFiring == false && bulletsInsideMagazine < startingMagazine)
        {
            bulletsInsideMagazine = startingMagazine;
            reloadNeccesary = false;
            reloadTimer = 0;
            reloading = true;
        }

        if (reloadTimer > amoutOfTimeNeccesaryToReload)
        {
            reloading = false;  
        }

        reloadTimer += Time.deltaTime;
    }




}
