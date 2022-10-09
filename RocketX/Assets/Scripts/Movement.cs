using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float boostSpeed = 800f;
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private AudioClip EngineBoost;

    [SerializeField] private ParticleSystem mainEngineParticles;
    [SerializeField] private ParticleSystem rightThrusterParticles;
    [SerializeField] private ParticleSystem leftThrusterParticles;
    
    Rigidbody rb;
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
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    private void StopThrusting()
    {
        audioSource.Stop();
        mainEngineParticles.Stop();
    }

    private void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * boostSpeed * Time.deltaTime);

        // Play sound only if we're not already playing
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(EngineBoost);
        }

        // Show particles only if it's not already shown
        if (!mainEngineParticles.isPlaying)
        {
            mainEngineParticles.Play();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else
        {
            StopRotation();
        }
    }

    private void StopRotation()
    {
        rightThrusterParticles.Stop();
        leftThrusterParticles.Stop();
    }

    private void RotateRight()
    {
        Rotate(Vector3.back);
        if (!leftThrusterParticles.isPlaying)
        {
            leftThrusterParticles.Play();
        }
    }

    private void RotateLeft()
    {
        Rotate(Vector3.forward);
        if (!rightThrusterParticles.isPlaying)
        {
            rightThrusterParticles.Play();
        }
    }

    void Rotate(Vector3 vec)
    {
        rb.freezeRotation = true; // freezing rotation so that we can manually rotate
        transform.Rotate(vec * rotationSpeed * Time.deltaTime);
        rb.freezeRotation = false; // unfreezing rotation back
    }
}
