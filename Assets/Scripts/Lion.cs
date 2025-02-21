using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;

public class Lion : Animal, AnimalInteractable
{

    public bool AnimalRange = false;
    public GameObject player;
    public GameObject canvas;
    public TextMeshProUGUI tmp;
    public float timer = 1.5f;
    public void AnimalInteraction()
    {
        timer = 1.5f;
        canvas.SetActive(true);
        tmp.SetText("Rawr");
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && AnimalRange == true)
        {
            AnimalInteraction();
        }
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            canvas.SetActive(false);
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