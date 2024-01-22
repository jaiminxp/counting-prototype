using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> targets;

    [SerializeField]
    TextMeshProUGUI savedText, deadText;

    float spawnRate = 1.0f;
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
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
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
