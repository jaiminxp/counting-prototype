using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Transform shootPoint;

    [SerializeField]
    GameObject projectile;

    AudioSource audioSource;

    [SerializeField]
    AudioClip shootSound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        FollowCursor();

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void FollowCursor()
    {
        Vector3 mouse = Input.mousePosition;
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(new Vector3(mouse.x, mouse.y, 0));
        Vector3 forward = mouseWorld - transform.position;
        var rotation = Quaternion.LookRotation(forward, -Vector3.forward);
        rotation.x = 0;
        rotation.y = 0;
        transform.rotation = rotation;
    }

    void Shoot()
    {
        Instantiate(projectile, shootPoint.position, shootPoint.rotation);
        audioSource.PlayOneShot(shootSound, 0.8f);
    }
}
