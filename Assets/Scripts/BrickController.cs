using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    public float speed;
    public float curLifeTime;
    public float absLifeTime;
    public Vector2 angle;
    public Vector2 velocity;
    public bool isEnabled;

    // Update is called once per frame
    private void Update()
    {
        float dt = Time.deltaTime;
        //Vector2 mousePos = Input.mousePosition();

        transform.position = new Vector2(transform.position.x + velocity.x * dt, transform.position.y + velocity.y * dt);

        if (isEnabled)
        {
            curLifeTime -= dt;
        }
        if (curLifeTime <= 0)
        {
            isEnabled = false;
            this.gameObject.SetActive(false);
        }
    }

    public void fired(Vector2 angle)
    {
        curLifeTime = absLifeTime;
        velocity = angle * speed;
        isEnabled = true;
    }
}
