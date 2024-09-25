using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class M1L1Controller : MonoBehaviour
{
    public levelScriptableObject lso;

    public int astroidsDestroyed;

    public TextMeshProUGUI ast;

    public int levelcounter;

    

    // Start is called before the first frame update
    void Start()
    {
       astroidsDestroyed = lso.astroidsDestroyed;
    }

    // Update is called once per frame
    void Update()
    {
        ast.text = "Asteroids Left:" + astroidsDestroyed.ToString();

        if(astroidsDestroyed <= 0){
            Debug.Log("Level Completed");
            Time.timeScale = 0;
            levelcounter +=1;
            PlayerPrefs.SetInt("levelcounter",levelcounter);
            SceneManager.LoadScene(0);

        }
    }
}
