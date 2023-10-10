using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using App; 

public class ThemeManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Theme currentTheme; 
    public Button button; 
    public GameObject quad; 
    
    
    
    public Sprite lightIcon;
    public Sprite darkIcon; 
    public Material lightBackground; 
    public Material darkBackground; 
    public GameObject lightIlumination; 
    public GameObject darkIlumination; 


    void Start()
    {
        currentTheme = Theme.LightTheme;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ChangeLighting() {
        if (currentTheme == Theme.LightTheme) {
            darkIlumination.SetActive(false);
            lightIlumination.SetActive(true);
        } else if (currentTheme == Theme.DarkTheme) {
            lightIlumination.SetActive(false);
            darkIlumination.SetActive(true);
        }
    }

    private void ChangeIcon() {


        if (currentTheme == Theme.LightTheme) {
            button.image.sprite = lightIcon; 
        } else if (currentTheme == Theme.DarkTheme) {
            button.image.sprite = darkIcon; 
        }

    }

    private void ChangeBackground() {
        MeshRenderer renderer = quad.GetComponent<MeshRenderer>(); 
        if (currentTheme == Theme.LightTheme) {
            renderer.material = lightBackground;
        } else if (currentTheme == Theme.DarkTheme) {
            renderer.material = darkBackground;
        }
    }

    public void ToggleTheme()
    {
        currentTheme = (currentTheme == Theme.LightTheme) ? Theme.DarkTheme : Theme.LightTheme;
        ChangeIcon();
        ChangeBackground(); 
        ChangeLighting(); 
    }


}







    

