using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    public float speed;
    public int damage;

    public int pointVal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {

    }

    public void HurtPlayer(){
        Debug.Log("Ouch");
        GameObject.FindGameObjectWithTag("Player").GetComponent<Script_PlayerMovement>().damage(damage);
    }

    public void addPoints(){
        GameObject.FindGameObjectWithTag("GameController").GetComponent<Script_GameManager>().points += pointVal;
    }

    public void addPoints(int points){
        GameObject.FindGameObjectWithTag("GameController").GetComponent<Script_GameManager>().points += points;
    }


}
