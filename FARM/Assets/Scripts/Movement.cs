using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] Animator anim;
    [SerializeField] Animator clothes;
    [SerializeField] Animator hair;
    public float speed;
    // Update is called once per frame

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, vertical);
        AnimateMovement(direction);

        transform.position += direction * speed * Time.deltaTime;    
    }

    void AnimateMovement(Vector3 direction)
    {
        if(anim != null)
        {
            if(direction.magnitude > 0)
            {
                anim.SetBool("IsMoving", true);

                clothes.SetBool("IsMoving", true);
                
                hair.SetBool("IsMoving", true);

                anim.SetFloat("horizontal", direction.x);
                anim.SetFloat("vertical", direction.y);
                
                clothes.SetFloat("horizontal", direction.x);
                clothes.SetFloat("vertical", direction.y);

                hair.SetFloat("horizontal", direction.x);
                hair.SetFloat("vertical", direction.y);
            }
            else
            {
                anim.SetBool("IsMoving", false);
                
                clothes.SetBool("IsMoving", false);

                hair.SetBool("IsMoving", false);
            }
        }
    }
}
