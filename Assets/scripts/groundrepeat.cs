using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundrepeat : MonoBehaviour
{

    private float spritewidth;


    // Start is called before the first frame update
    void Start()
    {
        BoxCollider2D groundCollider = GetComponent<BoxCollider2D>();
        spritewidth = groundCollider.size.x;

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -spritewidth)
        {
            transform.Translate(Vector2.right * 2f *  spritewidth);
        }

    }
}
