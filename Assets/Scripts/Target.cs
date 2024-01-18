using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    GameObject Balloon;

    GameManager gameManager;

    float maxTorque = 5;
    float xRange = 8;
    float ySpawnPos = 6;
    float fallSpeed = 5;

    void Start()
    {
        transform.position = RandomSpawnPos();

        rb = GetComponent<Rigidbody>();
        rb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        rb.velocity = Vector3.down * fallSpeed;

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos, -1);
    }

    void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Projectile":
                Destroy(other.gameObject);
                AttachBalloon();
                break;
            case "Ground":
                Destroy(gameObject);
                gameManager.UpdateDeadScore();
                break;
        }

    }

    void AttachBalloon()
    {
        Balloon.SetActive(true);
        rb.angularVelocity = Vector3.zero;
        transform.rotation = Quaternion.identity;
        rb.velocity = Vector3.up * fallSpeed * 2;
        gameManager.UpdateSavedScore();
    }

}
