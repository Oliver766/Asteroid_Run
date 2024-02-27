using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject rocketprefab;
    public Transform rocketSpawnPoint1, rocketSpawnPoint2;

    public float fireInterval = 2f;
    private bool canFire = true;

    public Image healthBarFill;
    public float healthBarChangeTime = 0.5f;

   
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
        if (canFire)
        {
            // fire rockets
            FireRockets();
            canFire = false;

            StartCoroutine(ReloadDelay());
        }
    }

    private void FireRockets()
    {
        Instantiate(rocketprefab, rocketSpawnPoint1.position, Quaternion.identity);
        Instantiate(rocketprefab, rocketSpawnPoint2.position, Quaternion.identity);

    }
    private IEnumerator ReloadDelay()
    {
        //play reload sound
        yield return new WaitForSeconds(fireInterval);

        canFire = true;
    }

  public void onexitButton()
  {

        SceneManager.LoadScene("MenuScene");

  }

    

}
