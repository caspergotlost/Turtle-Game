using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy : MonoBehaviour
{


    public float speed;
    


    public float pointVal;

    public float damageModifier;

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
        addPoints((int)(-pointVal * damageModifier));
    }

    public void addPoints(){
        GameObject.FindGameObjectWithTag("GameController").GetComponent<Script_GameManager>().points += (int)pointVal;
    }

    public void addPoints(int points){
        GameObject.FindGameObjectWithTag("GameController").GetComponent<Script_GameManager>().points += points;
    }

 
}
