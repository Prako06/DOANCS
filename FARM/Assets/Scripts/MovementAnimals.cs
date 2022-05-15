using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAnimals : MonoBehaviour
{
    public float speed;
    public float randomX;
    public float randomY;
    public float minWaitTime;
    public float maxWaitTime;
    private Vector3 currentRandomPos;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        PickPosition();
    }

    void PickPosition()
    {       
        currentRandomPos = new Vector3(Random.Range(-randomX, randomX), Random.Range(-randomY, randomY), 0);      
        StartCoroutine(MoveToRandomPos());        
    }

    IEnumerator MoveToRandomPos()
    {
        float time = 0.0f;
        float rate = 1.0f / speed;
        Vector3 currentPos = transform.position;

        while (time < 1.0f)
        {
            animator.SetBool("isWalking", true);
            animator.SetFloat("horizontal", (currentRandomPos.x - transform.position.x));
            animator.SetFloat("vertical", (currentRandomPos.y - transform.position.y));
            time += Time.deltaTime * rate;
            transform.position = Vector3.Lerp(currentPos, currentRandomPos, time);
            yield return null;
        }

        float randomFloat = Random.Range(0.0f, 1.0f);
        if (randomFloat < 0.5f)
        {
            StartCoroutine(WaitForSomeTime());
        }
        else
        {          
            PickPosition();
        }           
    }

    IEnumerator WaitForSomeTime()
    {
        animator.SetBool("isWalking", false);
        yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));      
        PickPosition();
    }
}
