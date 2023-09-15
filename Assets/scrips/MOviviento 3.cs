using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MOviviento3: MonoBehaviour
{
    public float velMovement = 5f; // Velocidad de movimiento del personaje
    public float fuerzaJump = 7f; //Fuerza dle salto dle personaje 
    private bool enElsuelo = false; //Indicador si el personaje está en el suelo




    private Rigidbody2D rb;
    private Animator animator;
    private string nivelActual;
    private void Start()
    {
        // Obtener el nombre de la escena actual y almacenarlo en nivelActual
        nivelActual = SceneManager.GetActiveScene().name;
    }
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }


    void Update()
    {

        //movimiento horizonal
        float movimientoH = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(movimientoH * velMovement, rb.velocity.y);

        animator.SetFloat("Horizontal", Mathf.Abs(movimientoH));


        //Salto
        if (Input.GetKeyDown(KeyCode.Space) && enElsuelo)
        {
            rb.AddForce(new Vector2(0f, fuerzaJump), ForceMode2D.Impulse);
            enElsuelo = false;
            animator.SetBool("Suelo", true);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        if ((gameObject.transform.position.y < -11.08))
        {
            Debug.Log("Game over");
            SceneManager.LoadScene(nivelActual);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Verificar si el personaje está en el suelo
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enElsuelo = true;
            Debug.Log("Si toco el suelo");
            animator.SetBool("Suelo", false);
        }
    }

    }
   
