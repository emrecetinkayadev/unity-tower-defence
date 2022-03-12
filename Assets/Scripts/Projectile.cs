using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Projectile Settings")]
    [SerializeField] float projectileSpeed = 2f;
    [SerializeField] float projectileDamage = 100f;
    [SerializeField] int passEnemyThrough = 0;
    int passEnemy = 0;
    bool check = true;

    [Header("Rotate Settings")]
    [SerializeField] bool isRotating = false;
    [SerializeField] bool isClockwise = false;
    [SerializeField] float rotateSpeed = 0.2f;
    float rotz = 0f;


    private void FixedUpdate()
    {
        RotateClockwiseorNot(isClockwise, isRotating, rotateSpeed);
    }


    void AddSpeed()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed, 0);
    }

    private void RotateClockwiseorNot(bool clockwise, bool isRotating, float rotateSpeed)
    {
        Debug.Log("Rotating");
        if (isRotating)
        {
            if (clockwise)
            {
                rotz += rotateSpeed * -Time.deltaTime;
            }
            else
            {
                rotz += rotateSpeed * Time.deltaTime;
            }

            transform.rotation = Quaternion.Euler(0, 0, rotz);
        }       
    }

    private void Start()
    {
        AddSpeed();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        var health = collision.GetComponent<Health>();
        var attacker = collision.GetComponent<Attacker>();

        if(health && attacker)
        {
            health.DealDamage(projectileDamage);
            
            if (CalculateEnemyPass())
            {
                Destroy(gameObject);
            }           
        }
    }

    private bool CalculateEnemyPass()
    {
        if (check)
        {
            passEnemy = passEnemyThrough;
            check = false;
        }
        
        passEnemy -= 1;

        if (passEnemy <= 0)
        {
            check = true;
            Debug.Log(passEnemy);
            return true;          
        }
        return false;        
    }
}
