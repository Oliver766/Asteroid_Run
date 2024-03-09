using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Image healthBarFill;
    public float healthBarChangeTime = 0.5f;
    public PlayerController[] PlayerController;

    public int choice;
    public GameObject[] spaceship;

    public void ChangeHealthBar(int maxHealth, int currentHealth)
    {
        if (currentHealth < 0)
            return;

        float healthPct = currentHealth / (float)maxHealth;
        StartCoroutine(SmoothhealthBarChange(healthPct));
    }

    private IEnumerator SmoothhealthBarChange(float newFillAmt)
    {
        float elapsed = 0f;
        float oldFillamt = healthBarFill.fillAmount;
        while(elapsed <= healthBarChangeTime)
        {
            elapsed += Time.deltaTime;
            float currentFillAmt = Mathf.Lerp(newFillAmt, oldFillamt, elapsed / healthBarChangeTime);
            healthBarFill.fillAmount = currentFillAmt;
            yield return null;
        }
    }

    public void OnFireButtonClicked()
    {
        foreach(PlayerController go in PlayerController)
        {
            go.gameObject.SetActive(false);

        }
        PlayerController[choice].gameObject.SetActive(true);
        PlayerController[choice].FireRockets();
    }

  

  public void onexitButton()
  {

        SceneManager.LoadScene("MenuScene");

  }

    public void Start()
    {
        choice = PlayerPrefs.GetInt("choice");
        foreach (GameObject go in spaceship)
        {
            go.SetActive(false);
        }

        spaceship[choice].SetActive(true);
    }


}
