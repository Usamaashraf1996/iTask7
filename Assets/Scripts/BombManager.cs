using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombManager : MonoBehaviour
{
    public GameObject projectilePrefab;
    private GameObject player;
    public float timer = 10f;
    // Start is called before the first frame update
    void Start()
    {
       player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
        }

        if (Bomb.isLand && timer==0) { 
        Destroy(gameObject);
        
        }
        
    }
}
