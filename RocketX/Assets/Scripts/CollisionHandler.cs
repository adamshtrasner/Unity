using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delayTime = 0.5f;
    [SerializeField] AudioClip Success;
    [SerializeField] AudioClip DeathExplosion;
    
    
    AudioSource audioSource;

    private bool isTransitioning = false;
    int currentSceneIndex;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    void OnCollisionEnter(Collision other)
    {
        if (isTransitioning) { return; }
        
        switch (other.gameObject.tag)
        {
            case "Friendly":
                print("It's Friendly");
                break;
            case "Finish":
                ProcessSuccess();
                break;
            default:
                ProcessFailure();
                break;
        }
    }

    void ProcessFailure()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(DeathExplosion);
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", delayTime);
    }

    void ProcessSuccess()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(Success);
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", delayTime);
    }

    void ReloadLevel()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}
