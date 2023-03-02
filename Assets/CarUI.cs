using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;


public class CarUI : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject deathPanel;

#if UNITY_IOS
    private string gameID="4221692";
#else
    private string gameID="4221693";
#endif

    public AdmobController admob;

    void Start(){
        Advertisement.Initialize(gameID,false);
    }
    

    public void pause(){
        Time.timeScale=0;
        pausePanel.SetActive(true);

        if (addCnt%2==1 && Advertisement.IsReady()) {
                Advertisement.Show("Interstitial_Android");
        }

        addCnt++;
  
    }

    public void resume(){
        Time.timeScale=1;
        pausePanel.SetActive(false);
    }

    public void restart(){
        openScene(Application.loadedLevel);
    }

    public void openScene(int id){
        Time.timeScale=1;
        StartCoroutine(loadAsync(id));
    }

    static int addCnt=0;
    public void showDeathPanel(){
        if(addCnt%2==1){
            if(!admob.showIntersitionalAd()){
                if (Advertisement.IsReady()) {
                    Advertisement.Show("Interstitial_Android");
                }
            }
        }

        addCnt++;
        deathPanel.SetActive(true);
    }

    public GameObject loadingPanel;
    public Slider loadingSlider;
    IEnumerator loadAsync(int id)
    {
        AsyncOperation operation = Application.LoadLevelAsync(id);
        loadingPanel.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            loadingSlider.value = progress;
            yield return null;

        }
    }
}
