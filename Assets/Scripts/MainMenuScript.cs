using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

    public GameObject SettingsMenu;
    public GameObject MainPanel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MoreApps()
    {
        Application.OpenURL("https://play.google.com/store/apps/developer?id=Promedia+Studio");
    }

    public void Settings(bool openclose)//if settings is opened then false and if closed then true
    {
        float alpha = 0.5f;
        if(openclose)
        {
            alpha = 1f;
        }

        foreach (Button mainButton in MainPanel.GetComponentsInChildren<Button>())
        {
            if (!mainButton.CompareTag("Settings"))
            {
                mainButton.enabled = openclose;
            }
        }

        foreach (Transform childUI in MainPanel.GetComponentsInChildren<Transform>())
        {
            if(!childUI.CompareTag("Settings") && childUI.GetComponent<CanvasRenderer>())
            {
                childUI.GetComponent<CanvasRenderer>().SetAlpha(alpha);
                
            }
        }
        SettingsMenu.SetActive(!openclose);
    }
}
