using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrenchAnimator : MonoBehaviour
{
    [Header("Spin Settings")]
    public float spinSpeed = 720.0f; // Degrees per second for the fast spin
    public float spinDuration = 2.0f; // How long to spin

    [Header("Tumble Settings")]
    public float tumbleSpeed = 90.0f; // Degrees per second for the slow tumble
    public float tumbleDuration = 1.5f; // How long to tumble

    // --- You might need to change these axes depending on your model ---
    private Vector3 spinAxis = Vector3.up; // The axis for the fast spin (e.g., around its own handle)
    private Vector3 tumbleAxis = Vector3.right; // The axis for the slow tumble (end over end)


    void Start()
    {
        // Start the animation sequence
        StartCoroutine(AnimateWrench());
    }

    IEnumerator AnimateWrench()
    {
        // This loop will run forever, repeating the animation
        while (true)
        {
            // --- SPIN PHASE ---
            float timer = 0;
            while (timer < spinDuration)
            {
                // Rotate the wrench around its spinAxis at high speed
                transform.Rotate(spinAxis, spinSpeed * Time.deltaTime);
                timer += Time.deltaTime;
                yield return null; // Wait for the next frame
            }

            // --- TUMBLE PHASE ---
            timer = 0;
            while (timer < tumbleDuration)
            {
                // Rotate the wrench around the tumbleAxis at a slower speed
                transform.Rotate(tumbleAxis, tumbleSpeed * Time.deltaTime, Space.World);
                timer += Time.deltaTime;
                yield return null; // Wait for the next frame
            }
        }
    }
}
