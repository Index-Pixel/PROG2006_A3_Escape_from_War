using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavBehaviour : MonoBehaviour
{
	public void LoadMyScene(int scene){
		if (scene > 0 && scene <= SceneManager.sceneCountInBuildSettings) {
			SceneManager.LoadScene(scene);
		} else {
			Debug.Log("Error while loading scene in function LoadMyScene in NavBehaviour.cs");
			SceneManager.LoadScene(0);
		}
	}

	public void LoadNextScene()
	{
		Scene scene = SceneManager.GetActiveScene();
		LoadMyScene(scene.buildIndex + 1);
	}

	public void LoadPreviousScene()
	{
		Scene scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.buildIndex - 1);
	}


}
