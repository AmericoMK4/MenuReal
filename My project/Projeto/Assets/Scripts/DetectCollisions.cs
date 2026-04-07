using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DetectCollisions : MonoBehaviour
{

    public PlayerController1 player;
    private int pontos = 0;
    // Start is called before the first frame update
    void Start()
    {
      player = GameObject.FindWithTag("Player").GetComponent<PlayerController1>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
