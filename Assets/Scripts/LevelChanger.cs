﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour {
    public void ChangeLevel(int index) {
        SceneManager.LoadScene(1);
    }

    public void Quit() {
        Application.Quit();
    }
}
