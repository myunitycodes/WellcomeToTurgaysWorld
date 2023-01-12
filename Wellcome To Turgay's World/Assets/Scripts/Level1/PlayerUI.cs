using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public partial class Player
{
    int gemNumber;
    bool isTappedStart;
    GameObject mainMenuPanel;
   public GameObject finishPanel;

 
   
  

  
    public void BtnTapToStart()
    {
        isTappedStart = true;   
        mainMenuPanel.SetActive(false);
        gemNumber = PlayerPrefs.GetInt("GemNumber");
    }

    void UpdateGemNumberCollider()
    {
        gemNumber++;
        PlayerPrefs.SetInt("GemNumber",gemNumber);
        

    }

    AsyncOperation asyncLoad;
    IEnumerator CoLoadAsyncScene(string sceneName)
    {
        asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

        asyncLoad.allowSceneActivation = false;

        yield return new WaitUntil(() => asyncLoad.progress >= 0.9f);

        asyncLoad.allowSceneActivation = true;

    }

    public void Menu()
    {
        StartCoroutine(CoLoadAsyncScene("Scenes/Menu"));
    }
   

}
