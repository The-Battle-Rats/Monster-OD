using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class monsterScore : MonoBehaviour
{
    public static monsterScore instance;
    public TextMeshProUGUI text;
    public GameObject player;
    int score;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeScore(int value)
    {
        score += value; //Adds the value of the monster and adds it to the score or something idk how this works

        text.text = "X" + score.ToString();

        if (score >=4)
        {
            Camera.main.GetComponent<Transform>().Rotate(20, 20, 20);
        }

        if (score >= 6) 
        {
            destroyPlayer();
        }
    }

    void destroyPlayer() 
    {
        Destroy(player);


    }


}
