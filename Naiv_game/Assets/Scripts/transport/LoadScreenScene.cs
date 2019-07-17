using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadScreenScene : MonoBehaviour
{
    private bool loadScene = false;
    public string LoadingSceneName;
    public Text loadingText;
    public Slider sliderBar;
    public Image image;

    // Use this for initialization
    void Start()
    {

        //Hide Slider Progress Bar in start
        sliderBar.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && loadScene == false)
        {

            // ...set the loadScene boolean to true to prevent loading a new scene more than once...
            loadScene = true;

            //Visible Slider Progress bar
            sliderBar.gameObject.SetActive(true);

            // ...change the instruction text to read "Loading..."
            loadingText.text = "Loading...";

            image.gameObject.SetActive(true);

            // ...and start a coroutine that will load the desired scene.

            StartCoroutine(LoadNewScene(LoadingSceneName));
         


        }
    }



    // The coroutine runs on its own at the same time as Update() and takes an integer indicating which scene to load.
    IEnumerator LoadNewScene(string sceneName)
    {
      
        // Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);

        // While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
        while (!async.isDone)
        {
            float progress = Mathf.Clamp01(async.progress / 0.9f  );
          
           
            sliderBar.value = progress;
            int o = (int) (progress * 100f);

          
            loadingText.text  = o + "%";

          
            yield return null;

        }

    }

  

}

