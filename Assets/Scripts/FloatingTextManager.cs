using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingTextManager : MonoBehaviour
{
    //taken from class materials
    [SerializeField] private GameObject floatingTextContainer;
    [SerializeField] private GameObject textPrefab;

    List<FloatingText> floatingTextsList = new List<FloatingText>();

    // Update is called once per frame
    void Update()
    {
      foreach (FloatingText ftext in floatingTextsList)
        {
            ftext.UpdateFloatingText();
        }
    }

    private FloatingText getFloatingText()
    {
        FloatingText floatingTextObj = null;

        for (int i = 0; i < floatingTextsList.Count; i++)
       {
           if (!floatingTextsList[i].isActive)
           {
                floatingTextObj = floatingTextsList[i];
                break;
            }
        }

        if (floatingTextObj == null)
        {
           // Debug.Log("Create Floating Text");
            floatingTextObj = new FloatingText();
            floatingTextObj.gameObj = Instantiate(textPrefab, floatingTextContainer.transform);
            floatingTextObj.text = floatingTextObj.gameObj.GetComponent<Text>();
            floatingTextsList.Add(floatingTextObj);
        }

        return floatingTextObj;
    }

    public void Show(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        FloatingText ftext = getFloatingText();

        ftext.text.text = msg;
        ftext.text.fontSize = fontSize;
        ftext.text.color = color;
        ftext.gameObj.transform.position = position; // Camera.main.WorldToScreenPoint(position); // turns world coordinates to screen coordinates
        //Debug.Log(ftext.gameObj.transform.position);
        ftext.motion = motion;
        ftext.duration = duration;

        ftext.Show();
    }
}
