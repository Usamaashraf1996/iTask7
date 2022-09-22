using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private Animator playerAnim;
   // public ParticleSystem explosionParticle;
    // Start is called before the first frame update
    void Start()
    {
        //playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            Debug.Log("Game Over");
            //playerAnim.SetBool("Death_b", true);
            //playerAnim.SetInteger("Death_Type", 1);
        }
    }
}
