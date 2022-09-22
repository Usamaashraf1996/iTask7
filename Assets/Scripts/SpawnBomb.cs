using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBomb : MonoBehaviour
{
    public GameObject projectilePrefab;
   
    public float speed;
    private GameObject enemy;
    public static bool isLand;
    public static bool collideEnemy;
    private Rigidbody bomb;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.Find("Enemy");
       

       
        InvokeRepeating("launchbomb", 2.0f, 3.0f);
        Debug.Log("4");
    }

    // Update is called once per frame
    void Update()
    {
            
    }
    void launchbomb() {
       
        
            Instantiate(projectilePrefab, new Vector3(Enemy.instance.transform.position.x,Enemy.instance.transform.position.y+2,Enemy.instance.transform.position.z), Enemy.instance.transform.rotation);
            Debug.Log("3");
        

    }
   

}



