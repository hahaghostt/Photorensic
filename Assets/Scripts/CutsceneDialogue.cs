using System.Collections;
using System.Collections.Generic;
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

        public GameObject defaultSprite;
        public GameObject happySprite;
        public GameObject ExtraSprite;
        public GameObject People;

        public GameObject Katherine1;
        public GameObject objectToShow;
        public float delayInSeconds = 2f;
        public GameObject KillObject;

        public string[] Dialogue;
        public int placement;

        public TMPro.TextMeshProUGUI text2;

        public GameObject pressE;
        public GameObject TASK;
        public GameObject TASK2;

        public string[] Name;
        public TMPro.TextMeshProUGUI text3;
        public int Name2;

        public bool Options;
        public GameObject OptionsDialogue;

        public GameObject DestroyDoor;

        bool player_detection = false;

        void Start()
        {
            defaultSprite.SetActive(false);
            People.SetActive(false);
            happySprite.SetActive(false);
            ExtraSprite.SetActive(false);
            Options = false;
            KillObject.SetActive(true);
            Katherine1.SetActive(false);
            DestroyDoor.SetActive(true);


            Invoke("ShowObject", delayInSeconds);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                canva.SetActive(true);
        
                placement = 0;
                string[] name = new string[Name.Length];
                text3.text = Name[Name2];

                pressE.SetActive(false);
                d_template.SetActive(true);
                defaultSprite.SetActive(true);
                Katherine1.SetActive(false);
                UpdateDialogue();
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                placement += 1;
                UpdateDialogue();
            }
        }

        void UpdateDialogue()
        {
            if (placement < Dialogue.Length)
            {
                text2.text = Dialogue[placement];

                if (Dialogue[placement].Contains("welcome to the manor"))
                {
                    defaultSprite.SetActive(false);
                    ExtraSprite.SetActive(false);
                    happySprite.SetActive(true);
                }

                else if (Dialogue[placement].Contains("there has been a murder"))
                {
                    defaultSprite.SetActive(true);
                    ExtraSprite.SetActive(false);
                    happySprite.SetActive(false); 
                }

                else if (Dialogue[placement].Contains("I want you to investigate and take photos of any possible evidence"))
                {
                    defaultSprite.SetActive(false);
                    ExtraSprite.SetActive(true);
                    happySprite.SetActive(false);
                }


            }
            else
            {
                d_template.SetActive(false);
                defaultSprite.SetActive(false);
                happySprite.SetActive(false);
            }
        }
    }
}