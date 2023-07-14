using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerXP : MonoBehaviour
{
    public static PlayerXP Instance;

    public FloatingTextManager floatingTextManager;
    public Text xpText;


    public int currentXP;

    public void SetXP()
    {
        xpText.text = MainManager.Instance.xp + " XP";
        currentXP = MainManager.Instance.xp;
    }

    public void GetXP(int xp)
    {
        currentXP += xp;

        floatingTextManager.Show("+ " + xp + " !", 40, Color.grey, transform.position, Vector3.up, 2.5f);

        xpText.text = currentXP + " XP";

        UpdateXP(currentXP);

    }

    public void LoseXP(int xp)
    {
        currentXP -= xp;
        floatingTextManager.Show("- " + xp + " !", 40, Color.grey, transform.position, Vector3.up, 2.5f);

        xpText.text = currentXP + " XP";

        UpdateXP(currentXP);

    }

    public void UpdateXP(int xp)
    {
        MainManager.Instance.xp = xp;
    }

    private void Start()
    {
        if(MainManager.Instance != null)
        {
            SetXP();
        }
    }

    private void Awake()
    {
        
        Instance = this;
        
    }


}
