using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Script_PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject bullet;
    public GameObject gameManager;

    GameObject newBullet;
    public float moveFactorX;
    public float moveFactorY;

    public float cooldown;


    Vector3 pos;
    InputAction moveAction;
    InputAction shootAction;

    Animator animator;

    float timer;

    Vector3 offset = new Vector3(.3f, 0, 0);

    
       
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Shoot");
        pos = transform.position;
        animator = this.transform.GetChild(0).GetComponent<Animator>();

        timer = 0.0f;
        scoreText = GameObject.FindGameObjectWithTag("Score");
        //healthText.GetComponent<TextMeshProUGUI>().SetText("Health: " + health);

    }

    // Update is called once per frame
    void Update()
    {

        Vector2 moveVal = moveAction.ReadValue<Vector2>();
        pos.x += moveVal.x*moveFactorX*Time.deltaTime;
        pos.y += moveVal.y*moveFactorY*Time.deltaTime;
        transform.position = pos;

        timer += Time.deltaTime;

        if(shootAction.IsPressed() && (cooldown <= timer) && !(GameObject.FindGameObjectsWithTag("Bullet").Length >= 5)){
            newBullet = Instantiate(bullet);
            newBullet.transform.position = transform.position + offset;
            timer = 0.0f;
            gameManager.GetComponent<Script_GameManager>().shots += 1;
            GetComponent<AudioSource>().Play();
        }

        pos = transform.position;
        pos.y =  Mathf.Clamp(transform.position.y, -3.61f, 5.65f);
        pos.x =  Mathf.Clamp(transform.position.x, -8.4f, 8.35f);
        transform.position = pos;



    }


    


}
