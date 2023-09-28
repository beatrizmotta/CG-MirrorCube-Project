using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Teste : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    void OnTriggerEnter(Collider other) {
        
        Debug.Log($"Eu {gameObject.name} estou tocndo em {other.name}");

    }

    void Update()
    {
        
    }
}
