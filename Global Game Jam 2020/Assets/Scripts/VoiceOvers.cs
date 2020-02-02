using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VoiceOvers : MonoBehaviour
{
    private int dialogueLine = 0;

    public GameObject[] dialogues = new GameObject[13];

    public AudioSource[] voiceLines = new AudioSource[13];

    // Update is called once per frame
    private void Update()
    {
        if (dialogueLine == 0)
        {
            dialogues[0].SetActive(true);
            voiceLines[0].Play();
            dialogueLine++;
        }

        else if (dialogueLine == 1 && !voiceLines[0].isPlaying)
        {
            dialogues[0].SetActive(false);
            dialogues[1].SetActive(true);
            voiceLines[1].Play();
            dialogueLine++;
        }

        else if (dialogueLine == 2 && !voiceLines[1].isPlaying)
        {
            dialogues[1].SetActive(false);
            dialogues[2].SetActive(true);
            voiceLines[2].Play();
            dialogueLine++;
        }

        else if (dialogueLine == 3 && !voiceLines[2].isPlaying)
        {        
            dialogues[2].SetActive(false);
            dialogues[3].SetActive(true);
            voiceLines[3].Play();
            dialogueLine++;
        }

        else if (dialogueLine == 4 && !voiceLines[3].isPlaying)
        {
            dialogues[3].SetActive(false);
            dialogues[4].SetActive(true);
            voiceLines[4].Play();
            dialogueLine++;
        }

        else if (dialogueLine == 5 && !voiceLines[4].isPlaying)
        {
            dialogues[4].SetActive(false);
            dialogues[5].SetActive(true);
            voiceLines[5].Play();
            dialogueLine++;
        }

        else if (dialogueLine == 6 && !voiceLines[5].isPlaying)
        {
            dialogues[5].SetActive(false);
            dialogues[6].SetActive(true);
            voiceLines[6].Play();
            dialogueLine++;
        }

        else if (dialogueLine == 7 && !voiceLines[6].isPlaying)
        {
            dialogues[6].SetActive(false);
            dialogues[7].SetActive(true);
            voiceLines[7].Play();
            dialogueLine++;
        }

        else if (dialogueLine == 8 && !voiceLines[7].isPlaying)
        {
            dialogues[7].SetActive(false);
            dialogues[8].SetActive(true);
            voiceLines[8].Play();
            dialogueLine++;
        }

        else if (dialogueLine == 9 && !voiceLines[8].isPlaying)
        {
            dialogues[8].SetActive(false);
            dialogues[9].SetActive(true);
            voiceLines[9].Play();
            dialogueLine++;
        }

        else if (dialogueLine == 10 && !voiceLines[9].isPlaying)
        {
            dialogues[9].SetActive(false);
            dialogues[10].SetActive(true);
            voiceLines[10].Play();
            dialogueLine++;
        }

        else if (dialogueLine == 11 && !voiceLines[10].isPlaying)
        {
            dialogues[10].SetActive(false);
            dialogues[11].SetActive(true);
            voiceLines[11].Play();
            dialogueLine++;
        }

        else if (dialogueLine == 12 && !voiceLines[11].isPlaying)
        {
            dialogues[11].SetActive(false);
            dialogues[12].SetActive(true);
            voiceLines[12].Play();
            dialogueLine++;
        }

        if (dialogueLine == 13 && !voiceLines[12].isPlaying)
        {
            SceneManager.LoadScene("Game");
        }
    }
}
