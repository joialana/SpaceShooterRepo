using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinSound : MonoBehaviour
{
    // Start is called before the first frame update
    public float num;
    public GameObject trigger;
    public AudioSource audioClip;
    public int triggerType;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            trigger.SetActive(true);
            audioClip.Play();
        }
    }
}