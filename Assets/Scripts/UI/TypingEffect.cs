using TMPro;
using UnityEngine;
using System.Collections;

public class TypingEffect : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI endText; 
    [SerializeField] private float typingSpeed = 0.05f;
    [SerializeField] private AudioSource clickingAudio; 

    [TextArea(3, 10)]
    [SerializeField] private string fullMessage = "";

    void Start()
    {
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        endText.text = "";
        foreach (char letter in fullMessage)
        {
            endText.text += letter;
            clickingAudio.Play();
            yield return new WaitForSeconds(typingSpeed);
        }

     
    }
}
