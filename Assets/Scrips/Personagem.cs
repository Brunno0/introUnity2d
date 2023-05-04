using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour{
    //variáveis para definir:
    // speed: velocidade
    // jumpForce: força do pulo 
    // rig: controle do rigidbody do personagem
    // isJumping: boleando para indentificar se o objeto esta pulando
    public float speed, jumpForce;
    private Rigidbody2D rig;
    private bool isJumping;

    // A função Start() é um método especial em C# que faz parte do ciclo de vida de um objeto no Unity. Ela é executada uma única vez, no momento em que o objeto é ativado na cena do Unity.
    void Start()    {
        // pegando rigidbody do personagem
        rig = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
 void Update() {
    // atualiza a velocidade do objeto na direção horizontal
    rig.velocity = new Vector2(speed, rig.velocity.y);

    // verifica se o botão esquerdo do mouse foi pressionado e se o objeto não está pulando
    if(Input.GetMouseButtonDown(0) && !isJumping){
        // adiciona uma força de pulo no objeto na direção vertical
        rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        // define a variável isJumping como true para evitar múltiplos pulos simultâneos
        isJumping = true;
    }
}
 void OnCollisionEnter2D(Collision2D colisor) {
    // verifica se o objeto colidiu com uma camada camada 8 
    if (colisor.gameObject.layer == 8){
        // define a variável isJumping como false para permitir que o objeto pule novamente
        isJumping=false;
    }
}

}
