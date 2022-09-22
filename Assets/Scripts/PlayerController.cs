using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 20;
    public float ballRange = 50;
    public float xRange = 95;
    public float zRange = 77.14f;
    public GameObject projectilePrefab;
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip crashsound;
    private AudioSource playerAudio;
    public Vector3 eulerAngles;
    public static bool gameOver;
    


    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
         //playerAudio = GetComponent<AudioSource>();
        gameOver=false; 
       


    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
     
        

        horizontalInput = Input.GetAxis("Horizontal");
      
        if (Input.GetKeyDown(KeyCode.Space)&&gameOver==false) {
           // Instantiate(projectilePrefab,transform.position, projectilePrefab.transform.rotation);
           
            dirtParticle.Play();
        }
        if (Input.GetKey(KeyCode.RightArrow) && gameOver == false)
        {
            transform.eulerAngles = new Vector3(0, 90, 0);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
           

        }
        else
        if (Input.GetKey(KeyCode.LeftArrow) && gameOver == false)
        {
            transform.eulerAngles = new Vector3(0, -90, 0);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.DownArrow)) {
            transform.eulerAngles = new Vector3(0, -180, 0);
        transform.Translate(Vector3.forward* speed * Time.deltaTime);
        }
        

    }


    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.tag != "Land" && collision.gameObject.tag != "Bomb" )
        {
            gameOver = true;

            Debug.Log("Game Over");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("Death_Type", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
          //  playerAudio.PlayOneShot(crashsound, 1.0f);

        }
        else if (collision.gameObject.tag == "EnemyBomb") {

            gameOver = true;
        
        }
       
    }
    
}
