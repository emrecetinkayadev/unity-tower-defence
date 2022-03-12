using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] int lives = 1;
    [SerializeField]TextMeshProUGUI liveText;
    LevelLoader levelLoader;
    

    private void Start() {
        ShowLivesLeft();
        levelLoader = FindObjectOfType<LevelLoader>();
    }

    private void CountAttackerPass(){
        lives -= 1;
        ShowLivesLeft();
        levelLoader.CheckLivesforNextScene(lives);
    }

    private void ShowLivesLeft(){
        liveText.text = "Lives: " + lives.ToString();
    }

    private void DestroyPassedAttacker(Collider2D attackerColider){
        Destroy(attackerColider.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        CountAttackerPass();
        DestroyPassedAttacker(other);
    }

}
