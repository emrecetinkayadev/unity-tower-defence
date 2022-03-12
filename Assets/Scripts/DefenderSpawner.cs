using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;
    StarDisplay starDisplay;
    Defender[] _defenders;

    int prefabStarCost;

    private void Start()
    {
        starDisplay = FindObjectOfType<StarDisplay>();
    }


    public void PrefabStarCost(int prefabCost)
    {
        prefabStarCost = prefabCost;
    }

    private void OnMouseDown()
    {
        if (CheckPosisFill())
        {
            SpawnDefender(MousePostoGrid(GetMousePos()), defender, starDisplay.CheckEnoughStars(prefabStarCost));
        }
    }

    private bool CheckPosisFill()
    {
        _defenders = FindObjectsOfType<Defender>();

        bool check = true;

        foreach (Defender def in _defenders)
        {          
            if (new Vector2(def.transform.position.x, def.transform.position.y) == MousePostoGrid(GetMousePos()))
            {
                check = false;
            }
        }
        return check;
    }

    public void SetSelectedDefender(Defender selectedDefender)
    {
        defender = selectedDefender;
    }

    private void SpawnDefender(Vector2 mousePos,Defender defender, bool check)
    {
        if (check)
        {
            Instantiate(defender, mousePos, Quaternion.identity);
        }
        
    }

    private Vector2 GetMousePos()
    {
        Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 mouseWorldPoint = Camera.main.ScreenToWorldPoint(mousePos);
        return mouseWorldPoint;
    }

    private static Vector2 MousePostoGrid(Vector2 mouseWorldPoint)
    {
        mouseWorldPoint = new Vector2(Mathf.Round(mouseWorldPoint.x), Mathf.Round(mouseWorldPoint.y) + 0.1f);
        return mouseWorldPoint;
    }
}
