using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public int idx;
    private Button b;

    void Start()
    {
        b = GetComponent<Button>();
        b.onClick.AddListener(Click);
        if (PlayerPrefs.GetInt("Level" + idx, 0) == 0 && idx != 1) b.interactable = false;
    }

    void Click()
    {
        StartCoroutine(LoadNextScene()); 
    }

    IEnumerator LoadNextScene()
    {

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Level" + idx);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
