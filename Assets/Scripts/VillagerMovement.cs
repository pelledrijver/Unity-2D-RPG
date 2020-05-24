using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerMovement : MonoBehaviour {

    public float moveSpeed;
    private Rigidbody2D myRigidbody;
    public bool isWalking;
    public float walkTime;
    public float waitTime;
    private float walkCounter;
    private float waitCounter;
    private int WalkDirection;

    public Collider2D walkZone;
    private Vector2 minWalkpoint;
    private Vector2 maxWalkpoint;
    private bool hasWalkZone;

    public bool canMove;
    private DialogueManager theDM;

	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
        waitCounter = waitTime;
        walkCounter = walkTime;
        ChooseDirection();

        //als er een walkZone is dan moet de villager er zich binnen bevinden. Zo niet, dan kan het overal bewegen
        if(walkZone != null)
        {
            minWalkpoint = walkZone.bounds.min;
            maxWalkpoint = walkZone.bounds.max;
            hasWalkZone = true;
        }
        canMove = true;
        theDM = FindObjectOfType<DialogueManager>();
	}
	

	void Update () {

        if (!theDM.dialogueActive)
        {
            canMove = true;
        }

        if (!canMove)
        {
            myRigidbody.velocity = Vector2.zero;
            return;
        }
        if (isWalking)
        {
            walkCounter -= Time.deltaTime;


            //dit bepaalt de richting waar de inwoner heen beweegt. walkdirection is random
            switch (WalkDirection)
            {
                case 0:
                    myRigidbody.velocity = new Vector2(0, moveSpeed);
                    if(hasWalkZone && transform.position.y > maxWalkpoint.y)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;
                case 1:
                    myRigidbody.velocity = new Vector2(moveSpeed, 0);
                    if (hasWalkZone && transform.position.x > maxWalkpoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                        break;
                case 2:
                    myRigidbody.velocity = new Vector2(0, -moveSpeed);
                    if (hasWalkZone && transform.position.y < minWalkpoint.y)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;
                case 3:
                    myRigidbody.velocity = new Vector2(-moveSpeed, 0);
                    if (hasWalkZone && transform.position.x < minWalkpoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;
            }

            if (walkCounter < 0)
            {
                isWalking = false;
                waitCounter = waitTime;
            }

        }
        else
        {
            waitCounter -= Time.deltaTime;
            myRigidbody.velocity = Vector2.zero;
            if (waitCounter < 0)
            {
                ChooseDirection();
            }
        }
	}

    public void ChooseDirection()
    {
        WalkDirection = Random.Range(0, 4);
        isWalking = true;
        walkCounter = walkTime;

    }

}
