using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
   public void GotoGameScene()
    {
        SceneManager.LoadScene(1);
    }

}
