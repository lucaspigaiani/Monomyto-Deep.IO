using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text lifes;
    public Text points;
    public Text ammo;
    public GameObject reset;

    public void SetLife(int life) 
    {
        lifes.text = life + " lifes";
    }

    public void SetAmmo(int ammoAmount)
    {
        ammo.text = "Special ammo: " + ammoAmount;
    }

    public void SetPoints(int currentPoints) 
    {
        points.text = currentPoints.ToString();
    }

    public void ResetPanel()
    {
        reset.SetActive(true);
    }
}
