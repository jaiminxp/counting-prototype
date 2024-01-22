using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    GameObject Balloon;

    [SerializeField]
    ParticleSystem explosionParticle;

    [SerializeField]
    Animator animator;

    GameManager gameManager;

    AudioSource audioSource;

    [SerializeField]
    AudioClip balloonSound;

    float maxTorque = 5;
    float xStart = -15;
    float xEnd = 9;
    float ySpawnPos = 10;
    float fallSpeed = 8;
    float liftSpeed = 5;

    void Start()
    {
        transform.position = RandomSpawnPos();

        audioSource = GetComponent<AudioSource>();

        rb = GetComponent<Rigidbody>();
        rb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        rb.velocity = Vector3.down * fallSpeed;

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        animator.SetFloat("Speed_f", 1.0f);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(xStart, xEnd), ySpawnPos, -2);
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
                Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
                gameManager.UpdateDeadScore();
                break;
        }

    }

    void AttachBalloon()
    {
        Balloon.SetActive(true);

        rb.angularVelocity = Vector3.zero;
        transform.rotation = Quaternion.identity;
        rb.velocity = Vector3.up * liftSpeed * 2;

        audioSource.PlayOneShot(balloonSound, 0.5f);

        gameManager.UpdateSavedScore();
        animator.SetFloat("Speed_f", 0f);
    }

}
