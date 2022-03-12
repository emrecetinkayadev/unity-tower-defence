using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0.0f,5f)]
    float currentSpeed = 0f;
    GameObject currentTarget;

    [Header("Damage")]
    [SerializeField] float damageDealt = 50f ;
    [SerializeField] float scorePoint;

    // Update is called once per frame
    void Update()
    {
       transform.Translate(Vector3.left * Time.deltaTime * currentSpeed);
    }

    public void SetMovementSpeed(float newValue)
    {
        currentSpeed = newValue;
    }

    public void Attack(GameObject target)
    {
        currentTarget = target;

        GetComponent<Animator>().SetBool("isAttacking", true);

    }

    public void StrikeCurrentTarget()
    {
        if (!currentTarget) { return; }

        Health health = currentTarget.GetComponent<Health>();

        if (health)
        {
            health.DealDamage(damageDealt);
        }
    }
    
    private void FixedUpdate()
    {
        AnimationState();
    }

    private void AnimationState()
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
    }

    public float GetScorePointAttacker(){
        return scorePoint;
    }
}
