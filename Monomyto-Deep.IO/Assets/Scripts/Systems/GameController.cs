using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private int currentPoints;
    public UIController uIController;
    public bool playerIsDead;

    void Update()
    {
        if (playerIsDead && Input.GetKeyDown(KeyCode.R))
        {
            ResetScene();
        }
    }

    public void AddPoint(int pointToAdd) 
    {
        currentPoints += pointToAdd;
        uIController.SetPoints(currentPoints);
    }

    public void EndGame() 
    {
        playerIsDead = true;
        uIController.ResetPanel();
    }

    private void ResetScene() 
    {
        SceneManager.LoadScene("Main");
    }
}
