using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpeedPickUp : MonoBehaviour
{
    public float SpeedUpPercentage = 5.0f;
     public bool hasSpedPlayer = false;


    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
            {
            collision.collider.GetComponent<PlayerMove>().speed *= SpeedUpPercentage;
            hasSpedPlayer = true;
        }
        if (gameObject.CompareTag("Pick Up"))
        {
            gameObject.SetActive(false);
        }
    }

    private class PlayerMove
    {
        internal float speed;
    }
}