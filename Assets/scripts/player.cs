using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    private Rigidbody2D rbplayer;
    [SerializeField] private float upforce;
    [SerializeField] private Transform groundcheck;
    [SerializeField] private LayerMask ground;
    [SerializeField] private float radius;

    private Animator playeranimator;
    



    void Start()
    {
        rbplayer = GetComponent<Rigidbody2D>();
        playeranimator = GetComponent<Animator>();
        
    }
   // Update is called once per frame
    void Update()
    {
        bool ingrounded = Physics2D.OverlapCircle(groundcheck.position, radius, ground);
        playeranimator.SetBool("ingrounded", ingrounded);

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            if (ingrounded) 
            { 

                rbplayer.AddForce(Vector2.up * upforce); 
            }
            
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundcheck.position, radius);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {
            GameManager.Instance.showgameoverscreen();
            playeranimator.SetTrigger("die");
            Time.timeScale = 0f;
        }
    }
}
