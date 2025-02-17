using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class AnimalSignScript : MonoBehaviour, IInteractable
{
    public CircleCollider2D circleCollider;
    public GameObject player;
    public bool inRange = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && inRange == true)
        {
            Sign();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (player.transform.position == collision.transform.position)
        {
            inRange = true;
            Debug.Log("...Player In Range");
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        inRange = false;
    }

    public void Sign()
    {
        if (this.name == "SealExhibit")
        {
            Interact(0);
        }
        if (this.name == "LionExhibit")
        {
            Interact(1);
        }
        if (this.name == "MonkeyExhibit")
        {
            Interact(2);
        }
        if (this.name == "GiraffeExhibit")
        {
            Interact(3);
        }
    }

    public void Interact(int signnum)
    {
        switch (signnum)
        {
            case 0:
                Debug.Log("...This Exhibit is for the Seal, a carnivorous animal that resides in cool and icy terrain!");
                break;
            case 1:
                Debug.Log("...This Exhibit is for the Lion, a carnivorous animal that hunts in packs and is high up on the food chain!");
                break;
            case 2:
                Debug.Log("...This Exhibit is for the Monkey, an interesting creature with many features akin to that of a human! They swing around the jungle and eat bananas!");
                break;
            case 3:
                Debug.Log("...This Exhibit is for the Giraffe, a long-necked Herbivore that spends its time plucking the leaves off of trees! They often reside in warm, expansive locales, where not many obstacles reside.");
                break;
        }
    }
}
