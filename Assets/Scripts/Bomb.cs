using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private float bombExplosionTime = 3;
    public ParticleSystem bombExplosionParticle;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("BombExplosion", bombExplosionTime);
    }

    public void BombExplosion()
    {
        bombExplosionParticle.Play();
        Destroy(gameObject);
    }
}
