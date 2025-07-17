using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_SixRingController : Enemy
{
    // Start is called before the first frame update
    GameObject player;

    const float YSPEED = 2;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left*Time.deltaTime*speed;
        if(player.transform.position.y > transform.position.y)
            transform.position += Vector3.up*YSPEED*Time.deltaTime;
        if(player.transform.position.y < transform.position.y)
            transform.position += Vector3.down*YSPEED*Time.deltaTime;
        
        
    }

    private void OnTriggerEnter(Collider other){
        if(other.tag == "Bullet"){
            Object.Destroy(other.gameObject);
            Object.Destroy(this.gameObject);
            addPoints();
        }
        if(other.tag == "Player"){
            Object.Destroy(this.gameObject);
            HurtPlayer();
        }
        if(other.tag == "Deleter"){
            Debug.Log("Hit Deleter, removing object");
            Object.Destroy(this.gameObject);
        }
    }
}
