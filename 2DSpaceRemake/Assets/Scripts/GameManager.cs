using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject rocketprefab;
    public Transform rocketSpawnPoint1, rocketSpawnPoint2;

    public float fireInterval = 2f;
    private bool canFire = true;

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
