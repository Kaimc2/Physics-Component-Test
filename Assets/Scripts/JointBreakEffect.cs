using UnityEngine;

public class JointBreakEffect : MonoBehaviour
{
    public ParticleSystem breakEffect; // Assign a particle effect in the Inspector
    public AudioClip breakSound; // Assign a sound clip in the Inspector
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = FindObjectOfType<AudioSource>();
        breakEffect.gameObject.SetActive(false);
    }

    void OnJointBreak(float breakForce)
    {
        Debug.Log("Joint broken! Force: " + breakForce);

        if (breakEffect != null)
        {
            breakEffect.gameObject.SetActive(true);
            Instantiate(breakEffect, transform.position, Quaternion.identity);
            breakEffect.Play();
        }

        if (audioSource != null && breakSound != null)
        {
            audioSource.clip = breakSound;
            audioSource.Play();
        }
    }
}
