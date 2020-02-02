using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseVoiceLines : MonoBehaviour
{
    private int dialogueLine = 0;

    public GameObject[] dialogues = new GameObject[4];

    public AudioSource[] voiceLines = new AudioSource[3];

    public float timer = 7.0f;

    private void Start()
    {
        voiceLines[0].Play();
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            dialogues[0].SetActive(true);
        }

        else if (dialogueLine == 0 && timer < 0)
        {
            dialogues[0].SetActive(false);
            dialogues[1].SetActive(true);
            dialogueLine++;
        }

        else if (dialogueLine == 1 && !voiceLines[0].isPlaying)
        {
            dialogues[1].SetActive(false);
            dialogues[2].SetActive(true);
            voiceLines[1].Play();
            dialogueLine++;
        }

        else if (dialogueLine == 2 && !voiceLines[1].isPlaying)
        {
            dialogues[2].SetActive(false);
            dialogues[3].SetActive(true);
            voiceLines[2].Play();
            dialogueLine++;
        }

        else if (dialogueLine == 3 && !voiceLines[2].isPlaying)
        {
            //SceneManager.LoadScene("Game");
        }
    }
}
