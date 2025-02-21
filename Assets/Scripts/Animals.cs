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
    public Chameleon chameleon;

    float dChangeTimer = 0;

    Vector2 lionDirection;
    Vector2 sealDirection;
    Vector2 monkeyDirection;
    Vector2 chameleonDirection;
    void Start()
    {
        lion.maxHealth = 8;
        lion.curHealth = lion.maxHealth;
        lion.moveSpeed = 8;

        seal.maxHealth = 10;
        seal.curHealth = seal.maxHealth;
        seal.moveSpeed = 1;

        chameleon.maxHealth = 3;
        chameleon.curHealth = chameleon.maxHealth;
        chameleon.moveSpeed = 2;

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
            chameleonDirection = Random.insideUnitCircle;
            dChangeTimer = 0.2f;
        }
        lion.move(lionDirection, lion.moveSpeed);
        monkey.move(monkeyDirection, monkey.moveSpeed);
        chameleon.move(chameleonDirection, chameleon.moveSpeed);
    }
}