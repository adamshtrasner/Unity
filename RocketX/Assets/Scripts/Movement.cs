using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float boostSpeed = 800f;
    [SerializeField] private float rotationSpeed = 100f;
    
    AudioSource audioSource;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        //Fetch the AudioSource from the GameObject
        audioSource = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        ProcessBoost();
        ProcessRotation();
    }

    void ProcessBoost()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * boostSpeed * Time.deltaTime);
            
            // Play sound only if we're not already playing
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Rotate(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Rotate(Vector3.back);
        }
    }

    void Rotate(Vector3 vec)
    {
        rb.freezeRotation = true; // freezing rotation so that we can manually rotate
        transform.Rotate(vec * rotationSpeed * Time.deltaTime);
        rb.freezeRotation = false; // unfreezing rotation back
    }
}
