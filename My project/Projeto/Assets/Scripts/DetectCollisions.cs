using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    public GameObject player;
    public int vidaP =  -1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pizza"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Player"))
        {
            print("funciona");
            Destroy(this.gameObject);
            player.ControleVida(vidaP);

        }
    }
}
