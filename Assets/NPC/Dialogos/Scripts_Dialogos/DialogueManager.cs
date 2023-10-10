using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialogueCanvas;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI displayNameText;
    [SerializeField] private Animator portraitAnimator;


    private Story currentStory;

    public bool DialogueIsPlaying { get; private set; }

    private static DialogueManager instance;
    public static DialogueManager GetInstance() => instance;

    private const string SPEAKER_TAG = "speaker";

    private const string PORTRAIT_TAG = "portrait";


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Mais de uma instancia de dialogo na cena");
        }
        instance = this;
    }

    private void Start()
    {
        DialogueIsPlaying = false;
        dialogueCanvas.SetActive(false);
        dialoguePanel.SetActive(false);
    }

    private void Update()
    {
        if (!DialogueIsPlaying) { return; }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new(inkJSON.text);
        DialogueIsPlaying = true;
        dialogueCanvas.SetActive(true);
        dialoguePanel.SetActive(true);

        ContinueStory();
    }

    private IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(0.2f);

        DialogueIsPlaying = false;
        dialogueCanvas.SetActive(false);
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            // Define a próxima linha de dialogo
            dialogueText.text = currentStory.Continue();

            // Lida das tags
            HandleTags(currentStory.currentTags);
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }
    private void HandleTags(List<string> currentTags)
    {
        foreach (string tag in currentTags)
        {
            string[] splitTag = tag.Split(":");
            if (splitTag.Length != 2) { Debug.LogError($"Tag não analisada: {tag}"); }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();
            

            // Lida com a tag
            switch (tagKey)
            {
                case SPEAKER_TAG:
                    displayNameText.text = tagValue;
                    break;
                case PORTRAIT_TAG:
                    portraitAnimator.Play(tagValue);
                    break;
                default:
                    Debug.LogWarning("");
                    break;
            }

        }
    }
}
