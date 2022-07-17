using UnityEngine;

public class OnderinScriptiGeleneKadar : MonoBehaviour
{
    //kolları bacakları falan da önderin yaptığı gibi ayırmalıyım. 
    [SerializeField] GameObject[] _childs;
    GameManager _gameManager;

    [Header("DiceMan'imizin özelliklerini doldurma")]
    int _health = 1;
    int _attack = 1;
    int _moveSpeed = 1;

    public int SuccesfulThrowing { get; set; }

    void Awake()
    {
        
        //Diğer scene'e geçerken destroy olmamak
        DontDestroyOnLoad(gameObject);
        _gameManager = FindObjectOfType<GameManager>();

    }

    void Update()
    {

        
    }

    public void ModifyHealth(int value)
    {
        _gameManager.ShowText(value, "Health +++");

        _health += value;
        SuccesfulThrowing++;
        Debug.Log("health " + _health);
    }

    public void ModifyAttack(int value)
    {
        _gameManager.ShowText(value, "Attack +++");
        
        _attack += value;
        SuccesfulThrowing++;
        Debug.Log("attack " + _attack);
    }

    public void ModifyMoveSpeed(int value)
    {
        _gameManager.ShowText(value, "Move Speed +++");

        _moveSpeed += value;
        SuccesfulThrowing++;
        Debug.Log("movespeed " + _moveSpeed);
    }
}
