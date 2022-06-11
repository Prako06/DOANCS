using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
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

                anim.SetFloat("horizontal", direction.x);
                anim.SetFloat("vertical", direction.y);
            }
            else
            {
                anim.SetBool("IsMoving", false);
            }
        }
    }
}
