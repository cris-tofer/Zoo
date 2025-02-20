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
    //public Random rand = new Random();
    Animal Lion = new Lion();
    Animal Seal = new Seal();
    Animal Giraffe = new Giraffe();
    Animal Monkey = new Monkey();
    // Start is called before the first frame update
    void Start()
    {
        Lion.maxHealth = 8;
        Lion.curHealth = Lion.maxHealth;
        Lion.moveSpeed = 8;

        Seal.maxHealth = 10;
        Seal.curHealth = Seal.maxHealth;
        Seal.moveSpeed = 1;

        Giraffe.maxHealth = 20;
        Giraffe.curHealth = Giraffe.maxHealth;
        Giraffe.moveSpeed = 20;

        Monkey.maxHealth = 5;
        Monkey.curHealth = Monkey.maxHealth;
        Monkey.moveSpeed = 5;
    }

    // Update is called once per frame
    void Update()
    {
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
        //Lion.move(new Vector2(rand.Next(0, 1), rand(0, 1)));

        if (SealIsTurning == true)
        {
            AnimalInteraction();
            SealTimer += Time.deltaTime;
           
        }
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
            brick[brickNum].GetComponent<BulletController>().fired(mouseDirection);


            brickNum++;
        }
    }
}