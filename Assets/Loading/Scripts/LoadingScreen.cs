using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    static LoadingScreen instance;
    [SerializeField] GameObject panel;
    [SerializeField] Text loadingText;
    [SerializeField] int loadingSteps = 5;
    [SerializeField] string[] motd;
    [SerializeField] Image loadingProgressBar;

    Animator animator;
    AsyncOperation loadingScene;

    public static void LoadScene(string sceneName)
    {
        instance.panel.SetActive(true);
        instance.animator.SetTrigger("Fade in");
        instance.loadingScene =  SceneManager.LoadSceneAsync(sceneName);
        instance.loadingScene.allowSceneActivation = false;
        instance.StartCoroutine(instance.EnjoyUser());
    }

    IEnumerator EnjoyUser()
    {
        loadingProgressBar.fillAmount = 0;
        for (int i = 0; i < loadingSteps; i++)
        {
            yield return new WaitForSeconds(1.5f);
            loadingProgressBar.fillAmount+= 1f/loadingSteps;
            int index = Random.Range(0, motd.Length);
            loadingText.text = motd[index];
        }

        yield return new WaitForSeconds(1.5f);
        loadingScene.allowSceneActivation = true;
        animator.SetTrigger("Fade out");
        yield return new WaitForSeconds(1f);
        panel.SetActive(false);
    }

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }

        instance = this;
        animator = GetComponentInChildren<Animator>();
        DontDestroyOnLoad(gameObject);
        panel.SetActive(false);
    }

    void Update()
    {
        //loadingProgressBar.fillAmount = loadingScene.progress;
    }
}
