using UnityEngine;
using System.Collections;

public class LoadMainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
        StartCoroutine(LoadLevel(3));
	}
	
    IEnumerator LoadLevel(float delay)
    {
        yield return new WaitForSeconds(delay);
        Application.LoadLevel("Menu");
    }
}
