using UnityEngine;
using System.Collections;

public class LightFlicker : MonoBehaviour
{
   public Light lightSource;
    public float minWaitTime = 0.1f;
    public float maxWaitTime = 0.5f;
    public AudioSource lightSound;

    void Start()
    {
        StartCoroutine(FlickerRoutine());
        lightSound.Play();
    }

    IEnumerator FlickerRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
            lightSource.enabled = !lightSource.enabled; // Toggle on/off
        }
    }
}
