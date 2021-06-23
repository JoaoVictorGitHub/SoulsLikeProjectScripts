using UnityEngine;

public class CrateDestroy : MonoBehaviour
{
    public GameObject destroyedVersion;
    AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Die();
            audioManager.crateBrake.Play();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        Instantiate(destroyedVersion, transform.position, transform.rotation);
    }

}
