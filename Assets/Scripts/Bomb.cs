using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{ //public GameObject BombPrefab; public GameObject BombPrefab2; public GameObject BombPrefab3;
  
    private Rigidbody bomb;
    
    
    public float speed = 10;
    public float yRange = -10;
    public static bool isLand;
    public static bool collideEnemy;
    public float destroyTimer = 10f;
  
    // Start is called before the first frame update
    void Start()
    {
       
        bomb=GetComponent<Rigidbody>();
        
        isLand = false;
        collideEnemy = false;


        bomb.AddForce(transform.forward*speed,ForceMode.Impulse);
       
    }

    // Update is called once per frame
    void Update()
    {
        destroyTimer -= Time.deltaTime; 
       
        if (transform.position.y <yRange) {
            Destroy(this.gameObject);

        }
       

        }
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.tag=="Land")
        {
            bomb.isKinematic = true;
            isLand = true;
           

        }
        if(collision.gameObject.tag == "Enemy")
        {
            collideEnemy = true;
        }
    }
   




}
