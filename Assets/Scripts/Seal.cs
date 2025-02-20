using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seal : Animal
{

    public float fat;
    public void swim()
    {
        moveSpeed = curHealth;
    }
}