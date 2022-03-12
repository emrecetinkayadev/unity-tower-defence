using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int starCost = 100;
    StarDisplay starDisplay;

    private void Start()
    {
        starDisplay = FindObjectOfType<StarDisplay>();
        starDisplay.SpendStars(starCost);
    }

    public int GetStarCost()
    {
        return starCost;
    }

    public float ReturnGridYLocation()
    {
        return Mathf.Round(transform.position.y);
    }

}
