using UnityEngine;
using UnityEngine.SceneManagement; 

public class MenuManager : MonoBehaviour {
    public void Jogar() {
        SceneManager.LoadScene("Game");
    }

    public void Sair() {
        SceneManager.LoadScene("Menu");
    }

    public void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            Jogar();
        }

        if (Input.GetKeyDown(KeyCode.Return)) {
            Jogar();
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            Sair();
        }
    }
}
