using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace BGS.UI
{
    public delegate void DialogueHandler();

    [System.Serializable]
    public class Dialogue
    {
        [SerializeField]
        public List<string> Texts;
    }

    [System.Serializable]
    public class ShopDialogue : MonoBehaviour
    {
        [SerializeField]
        List<Dialogue> _dialogueList = new List<Dialogue>();

        [SerializeField]
        Text _textField;

        [SerializeField]
        Button _nextButton;

        [SerializeField]
        Button _openShopButton;

        int _currentStage = 0;
        int _stageDialogueIndex = 0;

        UIManager _uiManager;

        public void Setup(UIManager uiManager)
        {
            _uiManager = uiManager;
            _openShopButton.onClick.AddListener(() => _uiManager.OpenShop());
            _nextButton.onClick.AddListener(() => ProceedDialogue());
        }

        public void StartDialogue()
        {
            _textField.text = _dialogueList[_currentStage].Texts[0];

            if (_currentStage == 0)
            {
                _nextButton.gameObject.SetActive(true);
                _openShopButton.gameObject.SetActive(false);
            }
            else
            {

            }
        }

        public void ResetDialogue()
        {
            _stageDialogueIndex = 0;
        }
        public void ProceedDialogue()
        {
            _stageDialogueIndex++;
            if (_stageDialogueIndex < _dialogueList[_currentStage].Texts.Count)
            {
                _textField.text = _dialogueList[_currentStage].Texts[_stageDialogueIndex];
            }
            else
            {
                _currentStage++;
                _nextButton.gameObject.SetActive(false);
                _openShopButton.gameObject.SetActive(true);
            }
        }

        

        
        

        

        public event DialogueHandler OnDialogueFinished;

    }

}
