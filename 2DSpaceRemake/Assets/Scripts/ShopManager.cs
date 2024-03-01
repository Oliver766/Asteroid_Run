using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ShopManager : MonoBehaviour
{
    public GameObject[] spaceshipPrefabs;
    public Texture2D[] spaceshipTexttures;
    public GameObject currentSpaceship;

    #region singleton
    public static ShopManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        spaceshipTexttures = new Texture2D[spaceshipPrefabs.Length];
        for (int i = 0; i < spaceshipPrefabs.Length; ++i)
        {
            GameObject prefab = spaceshipPrefabs[i];
            Texture2D texture = AssetPreview.GetAssetPreview(prefab);
            spaceshipTexttures[i] = texture;
        }

        currentSpaceship = spaceshipPrefabs[0];
    }
    #endregion

    public void ChangeCurrentSpaceship(int idx)
    {
        currentSpaceship = spaceshipPrefabs[idx];
    }
}
