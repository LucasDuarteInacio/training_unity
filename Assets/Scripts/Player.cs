using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // SerializeField Permite que a variavel privada(encapsulada) seja vista na ui da engine
    [SerializeField] private float speed;
    [SerializeField] private float runSpeed;


    private Rigidbody2D rig;

    private float inicialSpeed;
    private bool _isRunning;
    private bool _isRolling;
    private Vector2 _direction;


    public bool isRunning
    {
        get { return _isRunning; }
        set { _isRunning = value; }
    }

    public bool isRolling
    {
        get { return _isRolling; }
        set { _isRolling = value; }
    }

    public Vector2 direction
    {
        get { return _direction; }
        set { _direction = value; }
    }





    private void Start()
    {
        // referencia a variavel ao componente
        rig = GetComponent<Rigidbody2D>();
        inicialSpeed = speed;
    }

    // Captura inputs e/ou logicas que nao envolvam fisicas
    private void Update()
    {
        OnInput();
        OnRun();
        OnRolling();
    }


    //Captura logicas que envolvam fisicas
    private void FixedUpdate()
    {
        OnMove();
    }




    #region Movement


    void OnInput()
    {
        // Input.GetAxisRaw pega o atalho do teclado configurado e, project Settings/input manager
        // Input.GetAxisRaw retorna sempre (1,-1) correspondente ao seu respectivo eixo
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void OnMove()
    {
        rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime);
    }

    void OnRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
            _isRunning = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = inicialSpeed;
            _isRunning = false;
        }
    }

    void OnRolling()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _isRolling = true;
        }

        if (Input.GetMouseButtonUp(1))
        {
            _isRolling = false;
        }
    }

    #endregion
}
