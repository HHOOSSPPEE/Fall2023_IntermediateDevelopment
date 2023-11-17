using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //public Gacha gacha;
    public static GameManager instance;
    private float waitTime = 2f;
    // Start is called before the first frame update
    public void SwitchScene(string newScene)
    {
        Debug.Log("switch scene called " + newScene);
        SceneManager.LoadScene(newScene);
        StartCoroutine(SceneWait(waitTime, newScene));
    }

      



IEnumerator SceneWait(float waitTime, string newScene)
    {

        //everything here works right away
        yield return new WaitForSeconds(waitTime);

        //everything down here hap[ens after the wait
        SceneManager.LoadScene(newScene);
    }
    /*void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            gacha.CharacterList();
        }
    }*/
}
