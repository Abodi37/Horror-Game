using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlowManager : MonoBehaviour
{
    public GameObject winPanel;
    public GameObject losePanel;

    // Update is called once per frame
     private void OnTriggerStay(Collider other)
    {
        // Press 'E' or Action button to open
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
           WinGame();
        }
    }
    public void WinGame()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void LoseGame()
    {
        losePanel.SetActive(true);
        Time.timeScale = 0f;  
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
