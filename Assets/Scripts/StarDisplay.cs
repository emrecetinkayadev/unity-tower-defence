using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] int starPoints = 500;
    [SerializeField]Text starText;

    
    void Start()
    {
        ShowStarPoints();
    }

    public void ShowStarPoints()
    {
        starText.text = starPoints.ToString();
    }

    public void SpendStars(int spend)
    {
        if (starPoints >= spend)
        {
            starPoints -= spend;
            ShowStarPoints();
        }
    }

    public void AddStars(int value)
    {
        starPoints += value;
        ShowStarPoints();
    }

    public bool CheckEnoughStars(int checkStar)
    {
        return starPoints >= checkStar;
    }
}
