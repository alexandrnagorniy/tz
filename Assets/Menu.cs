﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
	public void MoveToScene(string sceneName)
	{
		SceneManager.LoadScene (sceneName);
	}

	public void Exit()
	{
		Application.Quit ();
	}

}
