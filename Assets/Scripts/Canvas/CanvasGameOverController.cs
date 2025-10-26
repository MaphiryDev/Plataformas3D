using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasGameOverController : MonoBehaviour
{
    [SerializeField] private GameObject gameOver;



    public void GameOver()
    {
        gameOver.SetActive(true);
    }

    public void ReiniciarJuego()
    {
        gameOver.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BotonAtras()
    {
        SceneManager.LoadScene("Menu");
    }
}
