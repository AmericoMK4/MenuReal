using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using TMPro;

public class DetectCollisions : MonoBehaviour
{

    public PlayerController1 player;
    public bool controleTamanho = false;
    private int pontos = 0;
    // Start is called before the first frame update
    void Start()
    {
      player = GameObject.FindWithTag("Player").GetComponent<PlayerController1>();
       
    }
    void awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     if (controleTamanho == true)
        {
            transform.localScale = new Vector3(5f, 5f, 5f);
        }
     if (controleTamanho == false)
        {
            transform.localScale = new Vector3(2f, 2f, 2f);
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Animais"))
        {
            player.Pontos(1);
            Destroy(gameObject);
            Destroy(other.gameObject);
         
        }
     
    }
    public void AumentoPizza(bool valor)
    {
        controleTamanho = valor; ;
    }
}
