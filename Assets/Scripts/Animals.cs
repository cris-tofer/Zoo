using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Animals : MonoBehaviour, AnimalInteractable
{
    public CircleCollider2D circle;
    public GameObject player;
    public bool AnimalRange = false;
    public bool SealIsTurning = false;
    public float SealTimer = 0;
    public SpriteRenderer spr;
    public GameObject[] brick;
    public int brickNum;
    public Lion lion;
    public Seal seal;
    public Monkey monkey;
    public Giraffe giraffe;

    float dChangeTimer = 0;

    Vector2 lionDirection;
    Vector2 sealDirection;
    Vector2 monkeyDirection;
    Vector2 giraffeDirection;
    // Start is called before the first frame update
    void Start()
    {
        lion.maxHealth = 8;
        lion.curHealth = lion.maxHealth;
        lion.moveSpeed = 8;

        seal.maxHealth = 10;
        seal.curHealth = seal.maxHealth;
        seal.moveSpeed = 1;

        giraffe.maxHealth = 20;
        giraffe.curHealth = giraffe.maxHealth;
        giraffe.moveSpeed = 20;

        monkey.maxHealth = 5;
        monkey.curHealth = monkey.maxHealth;
        monkey.moveSpeed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        dChangeTimer -= Time.deltaTime;

        if (Input.GetKeyUp(KeyCode.E) && AnimalRange == true)
        {
            if (this.name == "Seal")
            {
                SealIsTurning = true;
            }
            else
            {
                AnimalInteraction();
            }
        }

        if (SealIsTurning == true)
        {
            AnimalInteraction();
            SealTimer += Time.deltaTime;
           
        }
        else
        {
            seal.move(sealDirection, seal.moveSpeed);
        }

        if (dChangeTimer <= 0)
        {
            lionDirection = Random.insideUnitCircle;
            sealDirection = Random.insideUnitCircle;
            monkeyDirection = Random.insideUnitCircle;
            giraffeDirection = Random.insideUnitCircle;
            dChangeTimer = 0.2f;
        }
        lion.move(lionDirection, lion.moveSpeed);
        monkey.move(monkeyDirection, monkey.moveSpeed);
        giraffe.move(giraffeDirection, giraffe.moveSpeed);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (player.transform.position == other.transform.position)
        {
            AnimalRange = true;
            Debug.Log("Animal Sees Player");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        AnimalRange = false;
    }

    void AnimalInteraction()
    {
        float t = Time.realtimeSinceStartup;
        if (this.name == "Seal")
        {
            spr.color = Color.blue;
            Vector3 basePosition = new Vector3(-6.6f, 3.8f);
            float radius = 1.0f;
            transform.position = new Vector3(Mathf.Cos(t * 2.0f), Mathf.Sin(t * 2.0f)) * radius + basePosition;
            if (SealTimer > 2.5f)
            {
                transform.position = basePosition;
                SealIsTurning = false;
                SealTimer = 0;
                spr.color = new Color(0.566f, 0.566f, 0.566f);
            }
        }
        if (this.name == "Monkey")
        {
            brick[brickNum].SetActive(true);
            brick[brickNum].transform.position = transform.position;
            brick[brickNum].GetComponent<BrickController>().fired(player.transform.position - transform.position);


            brickNum++;
            if (brickNum > 2)
            {
                brickNum = 0;
            }
        }
        if (dChangeTimer <= 0)
        {
            lionDirection = Random.insideUnitCircle;
            dChangeTimer = 0.2f;
        }
        lion.move(lionDirection, lion.moveSpeed);
    }
}