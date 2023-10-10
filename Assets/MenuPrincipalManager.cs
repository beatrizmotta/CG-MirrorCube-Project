using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class MenuPrincipalManager : MenuManager {
    public GameObject painelMenuInicial; 
    public GameObject painelOpcoes; 
    public List<GameObject> cubes; 
    private int cubeIndex = 0; 

    public void Start() {
        painelOpcoes.SetActive(false);
        cubes[cubeIndex].SetActive(true);
    }

    public void AbrirOpcoes() {
        painelMenuInicial.SetActive(false);
        painelOpcoes.SetActive(true);
    }

    public void EscolherCube() {
        painelOpcoes.SetActive(false);
        painelMenuInicial.SetActive(true);
        PlayerPrefs.SetInt("cubeIdentifier", cubeIndex);
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
        cubes[cubeIndex].SetActive(false);

        if (cubeIndex + 1 == cubes.Count) {
            cubeIndex = 0;
        } else {
            cubeIndex++; 
        }

        cubes[cubeIndex].SetActive(true);
    }
}
