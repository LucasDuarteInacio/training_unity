using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Player player;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
       player = GetComponent<Player>();
       anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


        //sqrMagnitude pega o vetor2 e retorna o seu valor total ex: x = 0 y = 0 retorna 0,  x = 1 y = 1 retorna 1 ele retorna a media dos 2 parametros
        if (player.direction.sqrMagnitude > 0) 
        {
            anim.SetInteger("transition", 1);
        }
        else 
        {
            anim.SetInteger("transition", 0);
        }

        //direction verifica se o sprite esta indo para direita ou esquerda "x > 0 = direita","x < 0 = esquerda"
        if (player.direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }
}
