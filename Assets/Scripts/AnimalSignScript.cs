using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnimalSignScript : MonoBehaviour, IInteractable
{
    public CircleCollider2D circleCollider;
    public GameObject player;
    public bool inRange = false;
    public GameObject canvas;
    public GameObject ExhibitInfoCanvas;
    public TextMeshProUGUI exhibitInfo;
    public float canvasTimer;
    public bool canvasActive;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && inRange == true)
        {
            canvasActive = true;
            Sign();
            ExhibitInfoCanvas.SetActive(true);
            canvasTimer = 0;
        }
        if (canvasTimer <= 3.5f && canvasActive)
        {
            canvasTimer += Time.deltaTime;
        }
        if (canvasTimer >= 3.5f)
        {
            canvasActive = false;
            canvasTimer = 0;
            ExhibitInfoCanvas.SetActive(false);
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (player.transform.position == collision.transform.position)
        {
            inRange = true;
            Debug.Log("...Player In Range");
            canvas.SetActive(true);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        inRange = false;
        canvas.SetActive(false);
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
        if (this.name == "ChameleonExhibit")
        {
            Interact(3);
        }
    }

    public void Interact(int signnum)
    {
        switch (signnum)
        {
            case 0:
                exhibitInfo.SetText("...This Exhibit is for the Seal, a carnivorous animal that resides in cool and icy terrain!");
                break;
            case 1:
                exhibitInfo.SetText("...This Exhibit is for the Lion, a carnivorous animal that hunts in packs and is high up on the food chain!");
                break;
            case 2:
                exhibitInfo.SetText("...This Exhibit is for the Monkey, an interesting creature with many features akin to that of a human! They swing around the jungle and eat bananas!");
                break;
            case 3:
                exhibitInfo.SetText("...This Exhibit is for the Chameleon, a long-necked Herbivore that spends its time plucking the leaves off of trees! They often reside in warm, expansive locales, where not many obstacles reside.");
                break;
        }
    }
}
