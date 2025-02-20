using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public void move(Vector3 direction, float speed)
    {
        transform.position += direction * speed * Time.deltaTime;
    }
    public float moveSpeed;
    public float maxHealth;
    public float curHealth;
}