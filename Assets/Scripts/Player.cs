using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public float speed;
	private Rigidbody2D rig;
	private Vector2 _direction;

	public Vector2 direction
	{
		get { return _direction; }
		set { _direction = value; }
	}

	private void Start()
	{
		// referencia a variavel ao componente
		rig = GetComponent<Rigidbody2D>();
	}

	// Captura inputs e/ou logicas que nao envolvam fisicas
	private void Update()
	{
		// Input.GetAxisRaw pega o atalho do teclado configurado e, project Settings/input manager
		// Input.GetAxisRaw retorna sempre (1,-1) correspondente ao seu respectivo eixo
		_direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
	}


	//Captura logicas que envolvam fisicas
	private void FixedUpdate()
	{
		rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime);
	}
}
