using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(menuName = "Shop", fileName = "Spaceship")]
public class ScriptableObjectshop : ScriptableObject
{
    public GameObject starship;
    public string Name;
    [Range(0,50)]
    public int price;
    [Range(0,100)]
    public float speed;
    public bool unlocked;
    public int choice;
    
}
