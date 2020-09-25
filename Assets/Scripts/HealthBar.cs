using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class HealthBar : MonoBehaviour
{
    public float TotalHits = 10;
    public float HitsTaken = 0;
    float width = 500;
    float HealthRemaining;
    public bool isDed = false;
    [SerializeField]GameObject hpBar;
    [SerializeField] GameObject  resetScreen = null;
    void Update()
    {
        if (isDed == false) { 


        HealthRemaining = (TotalHits - HitsTaken) * (width / TotalHits);
        var hpBarchange = hpBar.transform as RectTransform;
        hpBarchange.sizeDelta = new Vector2(HealthRemaining, hpBarchange.sizeDelta.y);
    }
        if (HitsTaken == TotalHits)
        {
            //TODO add Death
            isDed = true;
            Ded();
        }

    }

    void Ded() 
    {
        GameObject Playa = GameObject.Find("Character");
        
        Playa.SetActive(false);
        resetScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
    
    
    }
}
