using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VillageStory : MonoBehaviour
{
    public Story story;
    public GameObject storybox;

    public void TriggerStory()
    {
        FindObjectOfType<StoryManager>().StartStory(story);
    }

    public void NextScene()
    {
        if (storybox.gameObject.activeSelf == false)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void Start()
    {
        
        TriggerStory();
    }

    public void Update()
    {
        Invoke("NextScene", 2f);
    }
}
