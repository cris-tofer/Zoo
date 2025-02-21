using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Chameleon : Animal, AnimalInteractable
{
    public GameObject player;
    public SpriteRenderer spr;
    public bool AnimalRange = false;
    public bool isChanged = false;
    public float changeTimer = 1;

    public void AnimalInteraction()
    {
        changeTimer = 1;
        float c1 = Random.value;
        float c2 = Random.value;
        float c3 = Random.value;
        Color c = new Color(c1, c2, c3);
        spr.color = c;
    }

    void Update()
    {
        if (changeTimer > 0)
        {
            changeTimer -= Time.deltaTime;
        }
        else
        {
            spr.color = new Color(0, 1, 0);
        }
        if (Input.GetKeyUp(KeyCode.E) && AnimalRange == true && changeTimer <= 0)
        {
            AnimalInteraction();
        }
    }
    void OnTriggerStay2D(Collider2D other)
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
}