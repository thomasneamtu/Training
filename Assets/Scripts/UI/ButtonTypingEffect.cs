using TMPro;
using UnityEngine;
using System.Collections;

public class ButtonTypingEffect : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] buttonLabels;
    [SerializeField] private string[] messages;
    [SerializeField] private float delayBetweenButtons = 0.5f;
    [SerializeField] private float typingSpeed = 0.05f;

    void Start()
    {
        StartCoroutine(TypeAllButtons());
    }

    IEnumerator TypeAllButtons()
    {
        for (int i = 0; i < buttonLabels.Length; i++)
        {
            yield return StartCoroutine(TypeOne(buttonLabels[i], messages[i]));
            yield return new WaitForSeconds(delayBetweenButtons);
       }
    }

    IEnumerator TypeOne(TextMeshProUGUI label, string message)
    {
        label.text = "";
        foreach (char c in message)
        {
            label.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

}
