using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour
{
    // Start is called before the first frame update

    private Text lifeText;
    private int lifeScoreCount;
    private bool canDamage;


    void Awake()
    {
        lifeText = GameObject.Find("LifeText").GetComponent<Text>();
        lifeScoreCount = 4;
        lifeText.text = "X" + lifeScoreCount;
        canDamage = true;
    }

    // Update is called once per frame
    public void DealDamage()

    
        {
        if (canDamage)
        {
            lifeScoreCount--;

            if (lifeScoreCount >= 0)
            {
                lifeText.text = "X" + lifeScoreCount;
            }

            if (lifeScoreCount == 0)
            {
                Time.timeScale = 0f;
                //SceneManager.LoadScene("ExitMenu");
                //StartCoroutine(RestartGame());

            }
            canDamage = false;
            StartCoroutine(WaitForDamage());

        }
    }
    IEnumerator WaitForDamage()
{
    yield return new WaitForSeconds(2f);
    canDamage = true;


}


IEnumerator RestartGame()
{
    yield return new WaitForSeconds(2f);
    //SceneManager.LoadScene("MainMenu");
}
}
