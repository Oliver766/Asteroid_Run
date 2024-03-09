using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonUpdate : MonoBehaviour
{
    public ScriptableObjectshop objectshop;

    public TextMeshProUGUI namext;


    public void Update()
    {
        namext.text = objectshop.Name;
    }


}
