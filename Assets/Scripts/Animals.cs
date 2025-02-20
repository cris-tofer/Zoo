using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animals : MonoBehaviour, AnimalInteractable
{
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
        //Lion.move(new Vector2(rand.Next(0, 1), rand(0, 1)));
    }

    void AnimalInteraction()
    {

    }
}