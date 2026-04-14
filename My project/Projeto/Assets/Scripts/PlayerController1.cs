using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System;

public class PlayerController1 : MonoBehaviour
{
    public GameSettings Gamesettings;
    public GameObject painel;
    public GameObject projectilePrefab;
    public DetectCollisions pizza;
    
    public float speed = 20f;
    private float xRange = 20f;
    public int vida = 3; 
    public int pontos = -0;
    private float horizontalInput;
    public bool CtrlVerdadeiro = false;
    public bool pizzaTrue = false;

    public InputActionAsset InputActions;
    private InputAction moveAction;
    private InputAction fireAction;
    private InputAction playerFantasma;
    private InputAction aumentarPizza;
    private InputAction pausaActionPlayer;
    private InputAction pausaActionUI;
    public TMP_Text vidaPlacar;
    public TMP_Text pontosPlacar;
 

    // Update is called once per frame  
    private void OnEnable()
    {
        InputActions.FindActionMap("Player").Enable();
    }
    private void OnDisable()
    {
        InputActions.FindActionMap("Player").Disable(); 
    }

    private void Awake()
    {

        moveAction = InputSystem.actions.FindAction("Move");
        fireAction = InputSystem.actions.FindAction("Jump");
        playerFantasma = InputSystem.actions.FindAction("Ghost");
        aumentarPizza = InputSystem.actions.FindAction("Power");
        pausaActionPlayer = InputSystem.actions.FindAction("Pausa");
        pausaActionUI = InputSystem.actions.FindAction("Despausa");

        
        Pontos(0); 
        Placar();
    }
     void Placar()
    {
         vidaPlacar.text = "Vidas: " + vida;
    }
public void Pontos(int quantidade)
    {
        pontos = pontos + quantidade;
        pontosPlacar.text = "Pontos: " + pontos; 
        if(pontos == 20)
        {
            SceneManager.LoadScene("Vitoria");
        }
    } 
  

    void Update()
    {
           
    
        float horizontalInput = moveAction.ReadValue<Vector2>().x;
        // movimenta o player para esquerda e direita a partir da entrada do usu�rio
        transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);
        // mant�m o player dentro dos limites do jogo (eixo x)
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.y);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.y);
        }
        if(fireAction.WasPressedThisFrame())
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);

        }

        if (playerFantasma.WasPressedThisFrame())
        {
            
            CtrlVerdadeiro = true;
            Gamesettings.Parametro(CtrlVerdadeiro);
        }
        if (aumentarPizza.WasPressedThisFrame()) 
        {
            pizzaTrue = true;
            pizza.AumentoPizza(pizzaTrue);
            StartCoroutine("Pizza");
        }
        if(pizzaTrue == false)
        {
            pizza.AumentoPizza(pizzaTrue);
        }

        if(vida < 1)
        {
            SceneManager.LoadScene("Morte");
        }
        PauseGame();
        
       
}
    IEnumerator Pizza()
    {
        yield return new WaitForSeconds(2);
        pizzaTrue = false;
    }

public void PauseGame()
    {
         if (pausaActionPlayer.WasPressedThisFrame())
        {
            painel.SetActive(true);
            InputActions.FindActionMap("Player").Disable(); 
            InputActions.FindActionMap("UI").Enable();
            Time.timeScale = 0;
        }
        if (pausaActionUI.WasPressedThisFrame())
        {
            painel.SetActive(false);
            InputActions.FindActionMap("Player").Enable(); 
            InputActions.FindActionMap("UI").Disable();
            Time.timeScale = 1;
        }
    }
    
   private void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Animais"))
        {
            vida = vida - 1;
            print(vida);
            Destroy(other.gameObject);
            Placar();

        }
    }
   
    }