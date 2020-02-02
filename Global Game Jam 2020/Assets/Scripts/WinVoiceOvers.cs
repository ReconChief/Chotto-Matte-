using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinVoiceOvers : MonoBehaviour
{
    private int dialogueLine = 0;

    public GameObject[] dialogues = new GameObject[9];

    public AudioSource[] voiceLines = new AudioSource[7];

    public float timer = 2.0f;
    public float secondTimer = 3.0f;
    
    void Update()
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

        else if (dialogueLine == 4 && timer > 0 && !voiceLines[3].isPlaying)
        {
            dialogues[3].SetActive(false);
            dialogues[4].SetActive(true);
            timer -= Time.deltaTime;
        }

        else if (dialogueLine == 4 && !voiceLines[3].isPlaying && timer < 0)
        {
            dialogues[4].SetActive(false);
            dialogues[5].SetActive(true);
            voiceLines[4].Play();
            dialogueLine++;
        }

        else if (dialogueLine == 5 && !voiceLines[4].isPlaying)
        {
            dialogues[5].SetActive(false);
            dialogues[6].SetActive(true);
            voiceLines[5].Play();
            dialogueLine++;
        }

        else if (dialogueLine == 6 && !voiceLines[5].isPlaying)
        {
            dialogues[6].SetActive(false);
            dialogues[7].SetActive(true);
            voiceLines[6].Play();
            dialogueLine++;
        }

        else if (dialogueLine == 7 && secondTimer > 0 && !voiceLines[6].isPlaying)
        {
            secondTimer -= Time.deltaTime;
            dialogues[7].SetActive(false);
            dialogues[8].SetActive(true);
        }

        else if (dialogueLine == 7 && !voiceLines[6].isPlaying && secondTimer < 0)
        {
            //SceneManager.LoadScene("Game");
        }
    }
}
