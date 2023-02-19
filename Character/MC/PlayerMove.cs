using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{

    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;
    public Text WINTEXT;
    public GameManagerScript gameManager;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.y);
        animator.SetFloat("Vertical", movement.x);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Artifact"))
        {
            Destroy(other.gameObject);
            AudioManager.instance.Play("pickupItem");
        }
        if (other.tag == "Win")
        {
            gameManager.gameWin();
            AudioManager.instance.Play("victory");
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
