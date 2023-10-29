using UnityEngine;

public class VolumeByDistance : MonoBehaviour
{
    public Transform listener; // Reference to the listener (e.g., the player character)
    public AudioSource audioSource;
    public float maxDistance = 10f; // Adjust this value to your liking

    private void Start()
    {
    }

    private void Update()
    {
        if (listener != null)
        {
            float distance = Vector2.Distance(listener.position, transform.position);

            // Calculate the volume based on distance
            float volume = 1f - (distance / maxDistance);
            volume = Mathf.Clamp01(volume); // Ensure it's within [0, 1]

            // Apply the calculated volume to the audio source
            audioSource.volume = volume;
        }
    }
}