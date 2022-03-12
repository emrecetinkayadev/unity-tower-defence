using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] GameObject particleDeathEffect;

    public void DealDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            PlayParticle();
            Destroy(gameObject);
        }
    }

    void PlayParticle()
    {
        if (particleDeathEffect != null)
        {
            GameObject particle = Instantiate(particleDeathEffect,new Vector3(transform.position.x - 0.7f,transform.position.y,transform.position.z),transform.rotation);
            Destroy(particle, 1f);            
        }
    }
  
}
