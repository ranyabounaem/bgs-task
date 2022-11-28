using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void DialogueHandler();
public class Dialogue : MonoBehaviour
{
    [SerializeField]
    List<string> _dialogue;

    public event DialogueHandler OnDialogueFinished;

    int currentIndex = 0;

    public string Next()
    {
        if (currentIndex < _dialogue.Count)
        {
            var __text = _dialogue[currentIndex];
            currentIndex++;
            return __text;
        }
        else
        {
            OnDialogueFinished?.Invoke();
            currentIndex = 0;
            return null;
        }
    }

    public void End()
    {

    }

}
