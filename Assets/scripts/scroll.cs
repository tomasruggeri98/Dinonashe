using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroll : MonoBehaviour
{

    


    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector2.left * GameManager.Instance.getscrollspeed() * Time.deltaTime);
        
    }
}
