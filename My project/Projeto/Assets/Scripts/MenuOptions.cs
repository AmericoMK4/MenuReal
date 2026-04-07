using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
public class MenuOptions : MonoBehaviour
{

   
    public GameObject painel;
    public GameObject painel2;
    public GameObject MenuPrincipal;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void Play()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Menu()
    {
        Time.timeScale =1f;
        SceneManager.LoadScene("Menu2");
    }
    public void Confirm()
    {
        painel.SetActive(true);
      
    }
    public void Opcoes()
    {
        painel2.SetActive(true);
        MenuPrincipal.SetActive(false);
    }
    public void Back()
    {
        painel.SetActive(false);
    }
    public void Back2()
    {
        painel2.SetActive(false);
        MenuPrincipal.SetActive(true);
    }
   public void Quit()
    {
        Application.Quit();
                #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
