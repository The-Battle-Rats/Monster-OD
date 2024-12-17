using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {


        if(other.gameObject.CompareTag("Player")){
            monsterScore.instance.changeScore(coinValue);
        }
    }

    
}
