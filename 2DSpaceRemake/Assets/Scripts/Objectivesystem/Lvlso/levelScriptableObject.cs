using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="levelScriptableObject",menuName ="scriptableObject/level")]
public class levelScriptableObject : ScriptableObject
{
    public bool LevelUnlocked;
    public bool LevelCompleted;

    public int astroidsDestroyed;

    public int levelscene;
    
}
