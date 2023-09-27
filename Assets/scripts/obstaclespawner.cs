using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaclespawner : MonoBehaviour
{

    [SerializeField] private GameObject[] obstacles;


    void Start()
    {
        StartCoroutine(spawnobstacle());
    }

    void Update()
    {
        
    }

    private IEnumerator spawnobstacle() 
    {

        while (true) 
        {
            int randomindex = Random.Range(0, obstacles.Length);
            float mintime = 0.6f;
            float maxtime = 1.8f;
            float randomtime = Random.Range(mintime, maxtime);

            Instantiate(obstacles[randomindex], transform.position, Quaternion.identity);
            yield return new WaitForSeconds(randomtime);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}
