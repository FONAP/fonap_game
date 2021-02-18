using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Player : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rigidbody2D;
    Vector2 move;

    public GameObject banRobber;

    public GameObject messageRobber;
    public GameObject messageLandSlide;
    public GameObject messageRiver;

    public float speed = 4f;

    public AudioSource clipFail;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        move = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        );

        /*
        transform.position = Vector3.MoveTowards(
            transform.position,
            transform.position + move,
            speed * Time.deltaTime
        );
        */

        if (move != Vector2.zero)
        {
            animator.SetFloat("moveX", move.x);
            animator.SetFloat("moveY", move.y);
            animator.SetBool("walking", true);
        }
        else
        {
            animator.SetBool("walking", false);
        }
    }

    void FixedUpdate()
    {
        rigidbody2D.MovePosition(rigidbody2D.position + move * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.CompareTag("Collision_Warning"))
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            messageLandSlide.SetActive(true);
            clipFail.Play();
        }

        if (collision.CompareTag("Collision_Warning_River"))
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            messageRiver.SetActive(true);
            clipFail.Play();
        }

        if (collision.CompareTag("Robber"))
        {
            banRobber.SetActive(true);
            messageRobber.SetActive(true);
            clipFail.Play();
        }
    }

    private void OnTriggerExit2D (Collider2D collision)
    {
        if (collision.CompareTag("Collision_Warning"))
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            messageLandSlide.SetActive(false);
        }

        if (collision.CompareTag("Collision_Warning_River"))
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            messageRiver.SetActive(false);
        }

        if (collision.CompareTag("Robber"))
        {
            banRobber.SetActive(false);
            messageRobber.SetActive(false);
        }
    }
}
