using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class Shooter : MonoBehaviour
{
    [Header("General Settings")]
    [SerializeField] GameObject thorn, gun;
    AttackerSpawner[] attackerSpawners;
    [SerializeField] List<AttackerSpawner> sortedAttackerSpawners = new List<AttackerSpawner>();
    Animator animator;

    [Header("Attack Speed")]
    [SerializeField][Range(1,10)] float attackSpeed = 5f;
    [SerializeField]float attackS = 10f;
    
    private void FixedUpdate()
    {
        CheckEnemyisonLine();      
    }

    private void AttackSpeedCalculate()
    {       
        attackS -= attackSpeed * Time.deltaTime;
        if(attackS <= 0)
        {
            attackS = 10f;
            Fire();
        }        
    }

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
         attackerSpawners = FindObjectsOfType<AttackerSpawner>();
         CorrectLineAttackerSpawner();
    }

    private void CorrectLineAttackerSpawner()
    {
        sortedAttackerSpawners = attackerSpawners.OrderBy(x => x.name).ToList();
    }

    public void Fire()
    {
        if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            GameObject projectile = Instantiate(thorn, gun.transform.position, Quaternion.identity);
        }    
    }

    public void CheckEnemyisonLine()
    {
        int line = (int)gameObject.GetComponent<Defender>().ReturnGridYLocation();

        if (sortedAttackerSpawners[line-1].transform.childCount > 0)
        {
            animator.SetBool("isAttack", true);
            AttackSpeedCalculate();
        }
        else
        {
            animator.SetBool("isAttack", false);
            ResetAttackCalculate();
        }
    }

    private void ResetAttackCalculate()
    {
        attackS = 10f;
    }


}
