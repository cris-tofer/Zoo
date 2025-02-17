using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;
    public Vector3 playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;
        playerTransform = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.A))
        {
            playerTransform.x -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerTransform.x += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerTransform.y -= 1;
        }
        if (Input.GetKey(KeyCode.W))
        {
            playerTransform.y += 1;
        }
        transform.position += playerTransform * speed * dt;
    }
}
