using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monkey : Animal, AnimalInteractable
{
    public CircleCollider2D circle;
    public GameObject player;
    public bool AnimalRange = false;
    public GameObject[] brick;
    public int brickNum;
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && AnimalRange == true)
        {
            AnimalInteraction();
        }
    }
    public void AnimalInteraction()
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
}