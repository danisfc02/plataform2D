using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu1 : MonoBehaviour
{

    public void LoadScene()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void Salir()
    {
        Application.Quit();
    }

}