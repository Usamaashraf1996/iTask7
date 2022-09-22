using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
//using static UnityEngine.ParticleSystem;

public class particle : MonoBehaviour
{
    private ParticleSystem particles;
    public float timer = 5f;

    // Start is called before the first frame update
    void Start()
    {
        particles = GetComponent<ParticleSystem>();
        particles.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if ((timer <= 2 && Bomb.isLand) || Bomb.collideEnemy)
        {
            Debug.Log("2");
            particles.Play();
        }
       
    }
}
