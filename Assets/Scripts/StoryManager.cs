using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryManager : MonoBehaviour
{
    public Text storyText;
    private Queue<string> sentences;
   

    public GameObject storybox;

    //takes sentences from story element and displays them one by one

    // Start is called before the first frame update
    void Awake()
    {
        sentences = new Queue<string>();

     
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            DisplayNextSentence();
        }
    }

    public void StartStory(Story story)
    {
       
        storybox.gameObject.SetActive(true);

        sentences.Clear();

        foreach (string sentence in story.sentences)
        {
            sentences.Enqueue(sentence);
        }

            DisplayNextSentence();
        
    }

   

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndStory();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {

        storyText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            storyText.text += letter;
            yield return null;
        }
    }

    void EndStory()
    {
        
        storybox.gameObject.SetActive(false);

    }
}
