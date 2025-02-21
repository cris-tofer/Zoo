using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seal : Animal, AnimalInteractable
{
    public CircleCollider2D circle;
    public GameObject player;
    public bool AnimalRange = false;
    public bool SealIsTurning = false;
    public float SealTimer = 0;
    public SpriteRenderer spr;
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && AnimalRange == true)
        {
            if (this.name == "Seal")
            {
                SealIsTurning = true;
                
            }
        }
        if (SealIsTurning == true)
        {
            AnimalInteraction();
            SealTimer += Time.deltaTime;
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
    public void AnimalInteraction()
    {

        float t = Time.realtimeSinceStartup;
        spr.color = Color.blue;
        Vector3 basePosition = new Vector3(-6, 3);
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
}