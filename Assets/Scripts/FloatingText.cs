using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingText 
{
    //taken from class materials
    public bool isActive;
    public GameObject gameObj;
    public Text text;
    public float duration;
    public Vector3 motion;
    public float lastShown;

    // call this when you want to activate the floating text
    public void Show()
    {
        isActive = true;
        lastShown = Time.time;
        gameObj.SetActive(true);
    }

    // call this when you want to deactivate (stop showing) the text
    public void Hide()
    {
        isActive = false;
        gameObj.SetActive(false);
    }

    /// <summary>
    /// Updates the parameters
    /// check if floating text is active and then show for specific duration then make it inactive
    /// update the position of object (move based on the Motion)
    /// </summary>
    public void UpdateFloatingText()
    {
        if (!isActive)
            return;

        if (Time.time - lastShown > duration)
            Hide();

        gameObj.transform.position += motion * Time.deltaTime;
        
    }
}

