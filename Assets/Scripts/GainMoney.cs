using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainMoney : MonoBehaviour
{
    private Coroutine logCoroutine;
    public GameManager gameManager;
    public ParticleSystem coinGain;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && logCoroutine == null) 
        {
            logCoroutine = StartCoroutine(LogMessage());
            coinGain.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && logCoroutine != null)
        {
            StopCoroutine(logCoroutine);
            logCoroutine = null;
            coinGain.Stop();
        }
    }

    private IEnumerator LogMessage()
    {
        while (true)
        {
            gameManager.character.money += 20;
            gameManager.UpdateMoney();
            yield return new WaitForSeconds(2f);
        }
    }
    
}
