﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;

public class MenuManager : MonoBehaviour {

	public enum menus {levelSelect, pauseMenu, startMenu, packMenu, ingameUI}
	GameObject[] menusArray = new GameObject[Enum.GetNames(typeof(menus)).Length];
	public bool inLevel = false;

	GameObject levelSelection, packSelection, pauseMenu, ingameUI;

	// Use this for initialization
	void Start () {
		levelSelection = GameObject.Find ("Level Selection");
		pauseMenu = GameObject.Find ("PauseMenu");
		packSelection = GameObject.Find("LevelPackPanel");
		ingameUI = GameObject.Find("IngameUI");
		menusArray [(int)menus.levelSelect] = levelSelection;
		menusArray [(int)menus.pauseMenu] = pauseMenu;
		menusArray [(int)menus.packMenu] = packSelection;
		menusArray[(int)menus.ingameUI] = ingameUI;

		if (menusArray [(int)menus.levelSelect] == null) {
			print("Unable to find level selection");
		}
		if (menusArray [(int)menus.pauseMenu] == null) {
			print("Unable to find pause menu");
		}
		if (menusArray [(int)menus.packMenu] == null) {
			print("Unable to find pack selection");
		}
		else {
			menusArray [(int)menus.pauseMenu].SetActive(false);
		}

	}

	public bool menuOpen (int menu){
		return menusArray [menu].activeSelf;
	}

	public void closeMenu (int m){
		inLevel = true;
		menusArray[m].SetActive(false);
	}

	public void openMenu (int m){
		inLevel = false;
		menusArray[m].SetActive(true);
	}

	public void returnToStart(){
		SceneManager.LoadScene("startUpMenu");
	}
}