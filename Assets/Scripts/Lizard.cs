using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Defender>())
        {
            gameObject.GetComponent<Attacker>().Attack(collision.gameObject);
        }
    }

}
