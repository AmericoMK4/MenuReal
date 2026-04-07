using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
public class MenuOptions : MonoBehaviour
{

   
    public GameObject painel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void Play()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu2");
    }
    public void Confirm()
    {
        painel.SetActive(true);
      
    }
    public void Back()
    {
        painel.SetActive(false);
    }
   public void Quit()
    {
        Application.Quit();
                #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
