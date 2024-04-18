using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    public void PlayLovLVl()
    {
        StartLovOrLvl.LovF_LvlT = true;
        StartCoroutine(Play());
    }

    IEnumerator Play()
    {
        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene("Lov");

    }
}
