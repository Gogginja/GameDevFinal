using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class collision : MonoBehaviour
{
    private int pelletValue = 2;
    private int PowerUpvalue = 50;
    private int ghostValue = 100;
    private int ghostAmount = 0;
    private int pelletAmount = 0;
    private int powerUpAmount = 0;
    public bool prey = true;
    private Vector3 originalPos;
    private Vector3 enemyOrigin;
    private int lifes = 3;
    private float duration = 0.0f;
    void Start()
    {
        originalPos = gameObject.transform.position;
    }

    void Update() 
    {
        if (duration<Time.time)
        {
            prey = true;
        }

        if ((pelletValue*pelletAmount + PowerUpvalue*powerUpAmount)==714){
            Debug.Log("You Win!");
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.transform.tag == "PowerUp")
        {
            powerUpAmount++;
            prey = false;
            Debug.Log("Score: " + (pelletValue*pelletAmount + PowerUpvalue*powerUpAmount + ghostValue*ghostAmount).ToString() + '\n');
            Destroy(other.gameObject);
            duration = Time.time + 5.0f;
        }
        else if (other.transform.tag == "Pellet")
        {
            pelletAmount++;
            Debug.Log("Score: " + (pelletValue*pelletAmount + PowerUpvalue*powerUpAmount + ghostValue*ghostAmount).ToString() + '\n');
            Destroy(other.gameObject);
        }
        else if (other.transform.tag == "Enemy" && prey == true)
        {
            lifes--;
            Debug.Log("Lives Left: " + lifes.ToString());
            gameObject.transform.position = originalPos;

        }
        else if (other.transform.tag == "Enemy" && prey == false)
        {
            ghostAmount++;
            Debug.Log("Score: " + (pelletValue*pelletAmount + PowerUpvalue*powerUpAmount + ghostValue*ghostAmount).ToString() + '\n');
            other.transform.position = new Vector3( 13.5f, 0.0f, 14.5f);
        }

        if (lifes<1)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }


    }
}
