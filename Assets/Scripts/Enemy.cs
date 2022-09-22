using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;
    private Rigidbody enemeyRb;
    private GameObject player;
    public static Enemy instance;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        enemeyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemeyRb.AddForce(lookDirection * speed);
        // transform.eulerAngles=new Vector3 (player.transform.rotation.x,180, player.transform.rotation.z);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.eulerAngles = new Vector3(0, 90, 0);
        }
        else
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.eulerAngles = new Vector3(0, -90, 0);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
        }
        
    }
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.CompareTag("Bomb"))
        {
            Destroy(gameObject);
            SpawnManager.instance.Add();
        }
    }

}