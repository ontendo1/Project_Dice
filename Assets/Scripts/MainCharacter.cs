using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCharacter : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float grav;
    [SerializeField] float _additionalJumpSpeed = 2f;
    Vector2 mousePos;
    [SerializeField] GameObject checkGroundObj;
    [SerializeField] bool onGround;
    [SerializeField] GameObject[] vucutParcalari;
    [SerializeField] GameObject[] vucutParcalariParentleri;
    GameManager _gameManager;
    float screenMid;
    float _jumpSpeed;

    [Header("DiceMan'imizin özelliklerini doldurma")]

    //buralarla oyna
    [SerializeField] int _health = 100;
    [SerializeField] int _attack = 5;
    [SerializeField] int _moveSpeed = 4;

    private void Awake()
    {
        screenMid = Screen.width / 2;
        rb = GetComponent<Rigidbody>();

        //canları geçiriyorum
        _gameManager = FindObjectOfType<GameManager>();

    }
    void Start()
    {
        vucutParcalari[1].transform.parent = vucutParcalariParentleri[1].transform;
        vucutParcalari[2].transform.parent = vucutParcalariParentleri[1].transform;

        _health = _gameManager.Heatlh;
        _attack = _gameManager.Attack;
        _moveSpeed = _gameManager.MoveSpeed;
        _jumpSpeed = _moveSpeed * _additionalJumpSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-_moveSpeed, rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(_moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)) && onGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, _jumpSpeed);
        }
        if (!onGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y - grav);


            if (transform.position.y < -30)
            {
                GameRestart();
            }
        }
        mousePos = Input.mousePosition;
        if (mousePos.x > screenMid)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        onGround = Physics.CheckSphere(checkGroundObj.transform.position, 0.15f, LayerMask.GetMask("Plane"));

        CheckHealth();
    }

    public void GetHit(int value)
    {
        _health -= value;
    }
    
    void GameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void CheckHealth()
    {
        if(_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}