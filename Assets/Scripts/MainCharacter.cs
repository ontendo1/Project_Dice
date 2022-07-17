using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCharacter : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed,jumpSpeed, grav;
    Vector2 mousePos;
    [SerializeField] GameObject checkGroundObj;
    [SerializeField] bool onGround;
    float screenMid;
    void Start()
    {
        screenMid = Screen.width / 2;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
        if((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)) && onGround) {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
        if (!onGround)
        {
            rb.velocity = new Vector2(rb.velocity.x,rb.velocity.y-grav);

            
            if(transform.position.y < -10) {
                GameRestart();
            }
        }
        mousePos = Input.mousePosition;
        if(mousePos.x > screenMid)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        onGround = Physics.CheckSphere(checkGroundObj.transform.position, 0.15f, LayerMask.GetMask("Plane"));

    }
    void GameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}