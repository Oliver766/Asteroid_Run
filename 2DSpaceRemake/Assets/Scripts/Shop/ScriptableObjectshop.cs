using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(menuName = "Shop", fileName = "Spaceship")]
public class ScriptableObjectshop : ScriptableObject
{
    public GameObject starship;
    public string Name;
    public int price;
    public bool unlocked;
}
