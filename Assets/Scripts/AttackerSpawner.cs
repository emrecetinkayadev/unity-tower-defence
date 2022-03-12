using System.Collections.Generic;
using System;
using System.Collections;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] Boolean spawnEnemies = true;
    [SerializeField] float minSpawnTime = 1f;
    [SerializeField] float maxSpawnTime = 5f;
    [SerializeField] Attacker[] _enemyPrefabs;

    List<Attacker> _attackerPool = new List<Attacker>();
    int poolChance = 100;

    int i;
  
    void Start()
    {
        AdjustAttackerPoolList();
        StartCoroutine (Spawn());
    }

    private IEnumerator Spawn()
    {
        while(spawnEnemies)
        {
            yield return new WaitForSeconds(RandomSpawnTime());
            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        Attacker newAttacker = Instantiate(ChooseRandomAttacker(), transform.position, transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }

    private float RandomSpawnTime()
    {
        float x;
        return x = UnityEngine.Random.Range(minSpawnTime,maxSpawnTime);     
    }
/*
    private Attacker ChooseRandomAttacker(){

        int foxChance = UnityEngine.Random.Range(1,10);

        if(foxChance == 1){
            return _enemyPrefabs[1];
        }

        return _enemyPrefabs[0];
    }
    */

    private Attacker ChooseRandomAttacker()
    {

        int random = UnityEngine.Random.Range(0, _attackerPool.Count - 1);

        return _attackerPool[random];

    }

    private void AdjustAttackerPoolList() //Adjust Attacker Pool List High Chance to Low
    {
        for (int i = 0; i < _enemyPrefabs.Length; i++)
        {            
            poolChance = (int) Mathf.Round(poolChance/2);

            for (int x = 0; x <= poolChance; x++)
            {
                _attackerPool.Add(_enemyPrefabs[i]);
            }
        }

    }



        
    

    


    

    
        
    

    

    

        
    
        
    

    

    
        
    

    

    
        
    

    
        
    

}
