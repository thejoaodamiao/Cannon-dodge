using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class playerMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private float dirX = 0f;
    [SerializeField]
    private float Lifes = 3f;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, -1.67f, 0);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        dirX = CrossPlatformInputManager.GetAxis("Horizontal");

        if (transform.position.x > 2.45f)
        {
            transform.position = new Vector3(2.45f, transform.position.y, 0);
        }
        else if (transform.position.x < -2.45f)
        {
            transform.position = new Vector3(-2.45f, transform.position.y, 0);
        }

    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX * speed, 0);
    }




}
