using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Animals : MonoBehaviour, AnimalInteractable
{
    public Lion lion;
    public Seal seal;
    public Monkey monkey;
    public Giraffe giraffe;

    float dChangeTimer = 0;

    Vector2 lionDirection;
    Vector2 sealDirection;
    Vector2 monkeyDirection;
    Vector2 giraffeDirection;

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
        giraffe.moveSpeed = 6;

        monkey.maxHealth = 5;
        monkey.curHealth = monkey.maxHealth;
        monkey.moveSpeed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        dChangeTimer -= Time.deltaTime;

        if (!seal.SealIsTurning)
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
}