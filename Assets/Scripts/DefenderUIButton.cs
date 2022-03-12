using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderUIButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;
    DefenderUIButton[] _defenceUI;
    DefenderSpawner defenderSpawner;

    private void SetDefenderCost()
    {
        defenderSpawner.PrefabStarCost(defenderPrefab.GetStarCost());
    }

    private void SetDefender()
    {
        defenderSpawner.SetSelectedDefender(defenderPrefab);
    }

    private void Start()
    {
        _defenceUI = FindObjectsOfType<DefenderUIButton>();
        defenderSpawner = FindObjectOfType<DefenderSpawner>();
    }

    private void OnMouseDown()
    {
        ChanceOtherObjectBlack();
        ChanceCurrentObjectWhite();
        SetDefender();
        SetDefenderCost();
    }

    private void ChanceCurrentObjectWhite()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
    }

    void ChanceOtherObjectBlack()
    {
        foreach (DefenderUIButton defenders in _defenceUI)
        {
            defenders.GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.3f, 0.3f, 1f);
        }
    }


}
