using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject target;

    [SerializeField]
    TextMeshProUGUI savedText, deadText;

    float spawnRate = 2.0f;
    float savedScore = 0;
    float deadScore = 0;

    void Start()
    {
        StartCoroutine(SpawnTarget());
    }

    IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            Instantiate(target);
        }
    }

    public void UpdateSavedScore()
    {
        savedScore++;
        savedText.text = "Saved: " + savedScore;
    }

    public void UpdateDeadScore()
    {
        deadScore++;
        deadText.text = "Dead: " + deadScore;
    }
}
