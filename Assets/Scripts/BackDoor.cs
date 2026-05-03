using UnityEngine;
using UnityEngine.SceneManagement;

public class BackDoor : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        // Press 'E' or Action button to open
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(3);
        }
    }
}
