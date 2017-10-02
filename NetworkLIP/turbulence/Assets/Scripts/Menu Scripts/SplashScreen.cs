using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour {
    public float waitTime;
    public Animator anim;
    public bool fadeIn = true;
    public bool fadeOut = false;
    public bool fadeStall = false;

	// Use this for initialization
	void Start () {
        StartCoroutine(splash());
        anim = GetComponent<Animator>();
        anim.SetBool("fadeIn", fadeIn);
    }

    // Update is called once per frame
    void Update () {
	
	}
    public IEnumerator splash()
    {
        anim.SetBool("fadeIn", fadeIn);
        yield return new WaitForSeconds(1.9f);

        fadeStall = true;
        fadeIn = false;
        
        anim.SetBool("fadeStall", fadeStall);
        anim.SetBool("fadeIn", fadeIn);
        yield return new WaitForSeconds(2.2f);

        fadeStall = false;
        fadeOut = true;
        anim.SetBool("fadeOut", fadeOut);
        anim.SetBool("fadeStall", fadeStall);

        yield return new WaitForSeconds(1.9f);

        SceneManager.LoadScene("Main Menu");

    }
}
