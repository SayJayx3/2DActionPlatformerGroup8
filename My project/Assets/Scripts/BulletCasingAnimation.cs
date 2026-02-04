using UnityEngine;
using System.Collections;
public class BulletCasingAnimation : MonoBehaviour
{
    private float destroyTimer;
    SpriteRenderer spriteRenderer;
    Animator animator;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        destroyTimer += Time.deltaTime;

        if(destroyTimer > 4f) 
        {
            animator.Play("BulletCasingAnimation");

        }

        if(destroyTimer > 5.5f)
        {
            Destroy(this.gameObject);
        }

        Debug.Log(destroyTimer);
    }
}
