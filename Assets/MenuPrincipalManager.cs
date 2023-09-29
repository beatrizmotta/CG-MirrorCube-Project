using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MenuPrincipalManager : MonoBehaviour
{

    public GameObject painelMenuInicial; 
    public GameObject painelOpcoes; 
    public List<GameObject> cubes; 
    private int cubeIndex = 0; 
    public ChangeTexture textureManager; 

    public void Start() {
        painelOpcoes.SetActive(false);
        cubes[cubeIndex].SetActive(true);
    }

    public void Jogar() {
        SceneManager.LoadScene("Game");
    }

    public void AbrirOpcoes() {
        painelMenuInicial.SetActive(false);
        painelOpcoes.SetActive(true);
    }

    public void EscolherCube() {
        painelOpcoes.SetActive(false);
        painelMenuInicial.SetActive(true);
        
        // Set active cube here

        string cubeName = cubes[cubeIndex].name;
        textureManager.changeTexture(cubeName);


    }

    public void BotaoEsquerda() {

        cubes[cubeIndex].SetActive(false);

        if (cubeIndex - 1 < 0) {
            cubeIndex = cubes.Count - 1;
        } else {
            cubeIndex--; 
        }

        cubes[cubeIndex].SetActive(true);

    }

    public void BotaoDireita() {

        Debug.Log("Bate rebate");

        cubes[cubeIndex].SetActive(false);

        if (cubeIndex + 1 == cubes.Count) {
            cubeIndex = 0;
        } else {
            cubeIndex++; 
        }

        cubes[cubeIndex].SetActive(true);

    }
}
