using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryElement : MonoBehaviour
{
    public Story story;

    //start the story element

    public void TriggerStory()
    {
        FindObjectOfType<StoryManager>().StartStory(story);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tera"))
        {
            TriggerStory();

        }
        else if (collision.gameObject.CompareTag("Kev"))
        {
            TriggerStory();

        }
        else
        {
            return;
        }
      
            Destroy(gameObject);
        
        
    }
}
