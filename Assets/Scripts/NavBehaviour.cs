using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NavBehaviour : MonoBehaviour
{

	private GameObject _lButton;
	private GameObject _nButton;
	private GameObject _mSound;
	private GameObject _mNarrator;
	private GameObject _info;
	private GameObject _home;
	private GameObject _infotext;
	private GameObject _pageSound;

	public void LoadMyScene(int scene){
		if (scene >= 0 && scene < SceneManager.sceneCountInBuildSettings-1) {
			SceneManager.LoadScene(scene);
		} else {
			Debug.Log("Error while loading scene in function LoadMyScene in NavBehaviour.cs");
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

	public void ReloadCurrentScene()
	{
		Scene scene = SceneManager.GetActiveScene();
		LoadMyScene(scene.buildIndex);
	}

	// called first
	void OnEnable()
	{
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	// called when the game is terminated
	void OnDisable()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		_lButton = GameObject.Find("LastPage");
		_nButton = GameObject.Find("NextPage");
		_mSound = GameObject.Find("SoundMute");
		_mNarrator = GameObject.Find("NarratorMute");
		_info = GameObject.Find("Information");
		_home = GameObject.Find("Home");
		_infotext = GameObject.Find("InfoTextPanel");
		_pageSound = GameObject.Find("PageSound");
		if (_lButton != null)
		{
			if(scene.buildIndex == 0)
				_lButton.GetComponent<Button>().interactable = false;
		}
		if (_home != null)
		{
			if (scene.buildIndex == 0)
				_home.GetComponent<Button>().interactable = false;
		}
		if (_nButton != null)
		{
			if (scene.buildIndex == 6)
				_nButton.GetComponent<Button>().interactable = false;
		}
		if (_mSound != null)
		{
			_mSound.GetComponent<Toggle>().isOn = SharedVariables.Instance.muteSound;
		}
		if (_mNarrator != null)
		{
			
			_mNarrator.GetComponent<Toggle>().isOn = SharedVariables.Instance.muteNarrator;
	
		}

		if (_pageSound != null)
		{
			_pageSound.SetActive(!SharedVariables.Instance.muteNarrator); ;
		}

		if (_info != null)
		{
			_info.GetComponent<Toggle>().isOn = SharedVariables.Instance.activeInfo;
		}

		if (_infotext != null)
		{
			_infotext.SetActive(SharedVariables.Instance.activeInfo);
		}
	}

	public void toggleSound()
	{
		SharedVariables.Instance.toggleSound();
	}

	public void toggleNarrator()
	{
		SharedVariables.Instance.toggleNarrator();
	}

	public void toggleInfo()
	{
		GameObject _infoAnim;
		SharedVariables.Instance.toggleInfo();
		if (_infotext != null)
		{
			_infotext.SetActive(SharedVariables.Instance.activeInfo);
		}
		_infoAnim = GameObject.Find("InfoAnim");
		if (_infoAnim != null)
		{
			_infoAnim.SetActive(false); ;
		}
	}
}
