using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trophy : MonoBehaviour
{
    [SerializeField] GameObject trophyEffect;
    [SerializeField] int trophyPointinTime = 3;
    StarDisplay starDisplay;

    private void Start()
    {
        starDisplay = FindObjectOfType<StarDisplay>();
    }

    public void ParticleAndPoint()
    {
        GameObject effect = Instantiate(trophyEffect, new Vector3(transform.position.x, transform.position.y + 0.25f, 0), Quaternion.identity);
        Destroy(effect, 1f);
        starDisplay.AddStars(trophyPointinTime);
    }
}
