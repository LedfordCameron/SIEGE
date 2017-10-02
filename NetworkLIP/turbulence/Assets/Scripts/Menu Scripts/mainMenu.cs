using UnityEngine;
using System.Collections;

public class mainMenu : MonoBehaviour {

    public GameObject mainSelection;
    public GameObject startup;
    public GameObject multiplayer;
    public GameObject settings;
    public GameObject sounds;
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void openMainSelection()
    {
        mainSelection.SetActive(true);
        startup.SetActive(false);
        //StartCoroutine(maintransition());
        
    }
    public void multiplayerSelection()
    {
        mainSelection.SetActive(false);
        multiplayer.SetActive(true);
    }
    public void backToMain()
    {
        multiplayer.SetActive(false);
        mainSelection.SetActive(true);
    }
    public void settingsBackToMain()
    {
        settings.SetActive(false);
        mainSelection.SetActive(true);
    }
    public void openSettings()
    {
        mainSelection.SetActive(false);
        settings.SetActive(true);
    }
    public void settingsToSounds()
    {
        settings.SetActive(false);
        sounds.SetActive(true);
    }
    public void soundsToSettings()
    {
        sounds.SetActive(false);
        settings.SetActive(true);
    }
   /*public IEnumerator maintransition()
    {
        yield return new WaitForSeconds(3f);
        mainSelection.SetActive(true);
        startup.SetActive(false);
    }*/
}
