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
    [SerializeField] GameObject diceMan; 
    [SerializeField] GameObject headDice,legDice1,legDice2,armDice1,armDice2, trunkDice;
    [SerializeField] bool onGround;
    [SerializeField] GameObject[] vucutParcalari;
    [SerializeField] GameObject[] vucutParcalariParentleri;
   
    float screenMid;
    private void Awake()
    {
        diceMan = GameObject.Find("DiceMAN");
        headDice = GameObject.Find("Head Dice");
        armDice1 = GameObject.Find("Arm 2 Dice");
        armDice2 = GameObject.Find("Arm 1 Dice");
        trunkDice = GameObject.Find("Trunk Dice");
        legDice1 = GameObject.Find("Leg 1 Dice");
        legDice2 = GameObject.Find("Leg 2 Dice");
        screenMid = Screen.width / 2;
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        vucutParcalari[0].transform.localPosition = headDice.transform.localPosition;
        vucutParcalari[1].transform.localPosition = armDice1.transform.localPosition;
        vucutParcalari[2].transform.localPosition = armDice2.transform.localPosition;
        vucutParcalari[3].transform.localPosition = trunkDice.transform.localPosition;
        vucutParcalari[4].transform.localPosition = legDice1.transform.localPosition;
        vucutParcalari[5].transform.localPosition = legDice2.transform.localPosition;
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