using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Animal
{
    public void move(Vector2 direction)
    {

    }
    public float moveSpeed;
    public float maxHealth;
    public float curHealth;
}
public class Seal : Animal
{

    public float fat;
    public void swim()
    {
        moveSpeed = curHealth;
    }
}
public class Monkey : Animal
{

    public float volume;
    public void sling()
    {

    }
    public void scream()
    {

    }
}
public class Lion : Animal
{

    public float volume;
    public void roar()
    {

    }
}
public class Giraffe : Animal
{

    public float neckLength;
    public void swingNeck()
    {

    }
}