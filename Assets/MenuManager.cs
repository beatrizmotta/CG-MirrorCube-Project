using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Play() {
        SceneManager.LoadScene("Game");
    }

    public void Exit() {
        SceneManager.LoadScene("Menu");
    }

    public void Update() {
        if (Input.GetKeyDown(KeyCode.Return)) {
            Play();
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            Exit();
        }
    }
}
