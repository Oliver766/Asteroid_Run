using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Data;

public class ButtonUpdate : MonoBehaviour
{
    public ScriptableObjectshop objectshop;

    public TextMeshProUGUI namext;

    public Button equipped;
  
    public Button buybtn;

    public bool unlocked;




    public int choice;




    void Start(){
        unlocked = objectshop.unlocked;
      
        namext.text = objectshop.name;
    }

   void Update(){
    if(unlocked == false ){
        buybtn.gameObject.SetActive(true);
        equipped.gameObject.SetActive(false);

    }
    if(unlocked == true){
             buybtn.gameObject.SetActive(false);
        equipped.gameObject.SetActive(true);

    }
 
    

   }

    public void equippedbtn(){
        
         choice = objectshop.choice;
         
        PlayerPrefs.SetInt("choice", choice);
        Debug.Log(choice);
   }

  

   public void buyFunc(){
    objectshop.unlocked = true;
    unlocked= true;

    int amount = objectshop.price;
    StatsController.inst_controller.money -= amount;
        PlayerPrefs.SetInt("Currency",StatsController.inst_controller.money);
 
    
   }

      
    



}
