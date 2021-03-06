﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    public GameObject theEnemy;
    public float enemyHealth;
    private float maxEnemyHealth;
    public bool canTurnRight;
    public bool canTurnLeft;

    public bool movingRight;
    public bool movingLeft;
    public bool facingRight;
    public bool facingLeft;
    public bool seen;
    public float distance;

    public Rigidbody2D enemyRigid;
    public float moveSpeed;

    public manager theManager;
    public characterMovement theCharacterMovement;

    // Start is called before the first frame update
    void Start()
    {
        maxEnemyHealth = 1;
        enemyHealth = maxEnemyHealth;

        canTurnRight = false;
        canTurnLeft = false;
        movingLeft = true;
        movingRight = false;
        facingRight = false;
        facingLeft = true;
        seen = false;

        enemyRigid = GetComponent<Rigidbody2D>();
        theManager = FindObjectOfType<manager>();
        theCharacterMovement = FindObjectOfType<characterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0)
        {
            Destroy(theEnemy.gameObject);
            Instantiate(theManager.enemyExplosion, theEnemy.transform.position, theEnemy.transform.rotation);
        }

        distance = Mathf.Abs(enemyRigid.gameObject.transform.position.x - theCharacterMovement.thePlayer.transform.position.x);

        //if (this.gameObject.GetComponent<enemyMovement>().distance <= 15 || this.gameObject.GetComponent<enemyMovement>().seen)
        //{
            //this.gameObject.GetComponent<enemyMovement>().seen = true;

            if (movingRight)
            {
                facingRight = true;
                facingLeft = false;

                canTurnLeft = true;
                canTurnRight = false;

                enemyRigid.velocity = new Vector3(moveSpeed, enemyRigid.velocity.y, 0f);
                transform.localScale = new Vector3(-4f, 4f, 0f);
            }
            else if (movingLeft)
            {
                facingRight = false;
                facingLeft = true;

                canTurnLeft = false;
                canTurnRight = true;

                enemyRigid.velocity = new Vector3(-moveSpeed, enemyRigid.velocity.y, 0f);
                transform.localScale = new Vector3(4f, 4f, 0f);
            }
        //}
    }

    public void HurtEnemyMethod(enemyMovement objectToHurt, float damageToTake)
    {
        objectToHurt.enemyHealth -= damageToTake;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground" || other.tag == "InvisibleGround")
        {
            if (movingLeft && canTurnRight)
            {
                movingRight = true;
                movingLeft = false;
            }
            else if (movingRight && canTurnLeft)
            {
                movingRight = false;
                movingLeft = true;
            }
        }
    }
}
    /*public GameObject theEnemy;
    public float enemyHealth;
    private float maxEnemyHealth;
    public GameObject pointA;
    public GameObject pointB;
    bool moveRight;


    public Transform leftPoint;
    public Transform rightPoint;
    public bool movingRight;
    public bool canTurnRight;
    public bool canTurnLeft;

    public bool movingRight;
    public bool movingLeft;
    public bool facingRight;
    public bool facingLeft;
    public bool seen;

    public Rigidbody2D enemyRigid;
    public float moveSpeed;

    public manager theManager;
    public characterMovement theCharacterMovement;

    // Start is called before the first frame update
    void Start()
    {
        maxEnemyHealth = 1;
        enemyHealth = maxEnemyHealth;
        //moveRight = false;
        enemyRigid = GetComponent<Rigidbody2D>();
        theManager = FindObjectOfType<manager>();
        theCharacterMovement = FindObjectOfType<characterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0)
        {
            Destroy(theEnemy.gameObject);
            Instantiate(theManager.enemyExplosion, theEnemy.transform.position, theEnemy.transform.rotation);
            theManager.AddCoins(100);

        }

        if (this.gameObject.transform.position.x >= pointB.transform.position.x && this.gameObject.transform.position.x <= pointA.transform.position.x)
        {
            enemyRigid.velocity = new Vector3(-moveSpeed, enemyRigid.velocity.y, 0f);
        }
        else if (this.gameObject.transform.position.x <= pointA.transform.position.x)
        {
            enemyRigid.velocity = new Vector3(moveSpeed, enemyRigid.velocity.y, 0f);
        }
        //if moveRight is false, move to point A
        if (moveRight == false)
        {
            enemyRigid.velocity = new Vector3(-moveSpeed, enemyRigid.velocity.y, 0f);
            transform.localScale = new Vector3(4f, 4f, 4f);
        }
        //check Location
        turnRight(transform.position, pointA.transform.position, pointB.transform.position);
        //if moveRight is true, move to point B
        if (moveRight == true)
        {
            enemyRigid.velocity = new Vector3(moveSpeed, enemyRigid.velocity.y, 0f);
            transform.localScale = new Vector3(-4f, 4f, 4f);
        }
    }

    public void HurtEnemyMethod(enemyMovement objectToHurt, float damageToTake)
    {
        objectToHurt.enemyHealth -= damageToTake;
    }

    public void turnRight(Vector3 enemyLocation, Vector3 pointALocation, Vector3 pointBLocation)
    {
        //check point A first
        float check = Vector3.Distance(pointALocation, enemyLocation);
        if (check <= 2)
        {
            moveRight = true;
        }
        check = Vector3.Distance(pointBLocation, enemyLocation);
        if (check <= 2)
        {
            moveRight = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            if (movingLeft && canTurnRight)
            {
                movingRight = true;
                movingLeft = false;
            }
            else if (movingRight && canTurnLeft)
            {
                movingRight = false;
                movingLeft = true;
            }
        }
    }*/
