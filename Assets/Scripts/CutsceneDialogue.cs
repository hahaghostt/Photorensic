using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

namespace Photorensic
{
    public class NPCSystem : MonoBehaviour
    {
        public GameObject d_template;
        public GameObject canva;

        public GameObject neutralSprite;
        public GameObject happySprite;
        public GameObject ExtraSprite;
        public GameObject surpriseSprite;

        public float textSpeed = 0.05f; // Speed at which the text is displayed

        public string[] Dialogue;
        public int placement;

        public TextMeshProUGUI text2TMP; // TextMeshPro for dialogue
        public TextMeshProUGUI text3TMP; // TextMeshPro for character name

        public GameObject pressE;
        public GameObject TASK;
        public GameObject TASK2;

        public string[] Name;
        public int Name2;

        public GameObject DestroyDoor;

        public string nextSceneName;

        [Header("Options")]
        public GameObject optionsPanel;
        public Button option1Button;
        public Button option2Button;
        public Button option3Button;

        private bool optionsDisplayed;

        void Start()
        {
            neutralSprite.SetActive(false);
            happySprite.SetActive(false);
            ExtraSprite.SetActive(false);
            surpriseSprite.SetActive(false);
            optionsPanel.SetActive(false);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                canva.SetActive(true);
                SetCharacterName();
                neutralSprite.SetActive(true);
                StartCoroutine(TypeDialogue());
            }
        }

        IEnumerator TypeDialogue()
        {
            string currentText = Dialogue[placement]; // Get the dialogue text for the current placement
            string displayedText = "";
            int textIndex = 0;

            text2TMP.text = displayedText;

            while (textIndex < currentText.Length)
            {
                displayedText += currentText[textIndex];
                text2TMP.text = displayedText;
                textIndex++;
                yield return new WaitForSeconds(textSpeed);
            }

            // Typing finished, check for options to be displayed
            if (Dialogue[placement].Contains("Excited for your first proper case?"))
            {
                optionsPanel.SetActive(true);
                optionsDisplayed = true;
            }

            // Increment placement if not currently typing options
            if (!optionsDisplayed && placement < Dialogue.Length)
            {
                placement++;
            }
        }

        void SetCharacterName()
        {
            text3TMP.text = Name[Name2];
        }

        public void SelectOption(int option)
        {
            switch (option)
            {
                case 1:
                    Debug.Log("Option 1 selected");
                    // Handle option 1
                    break;
                case 2:
                    Debug.Log("Option 2 selected");
                    // Handle option 2
                    break;
                case 3:
                    Debug.Log("Option 3 selected");
                    // Handle option 3
                    break;
                default:
                    break;
            }

            optionsPanel.SetActive(false); // Hide options panel after selecting an option
            optionsDisplayed = false; // Reset optionsDisplayed flag
        }
    }
}
