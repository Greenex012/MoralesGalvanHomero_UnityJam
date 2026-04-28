using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{

    private AudioSource _audio;

    private void Awake()
    {
        
        _audio = GetComponent<AudioSource>();

    }

    public void LoadMainScene()
    {

        _audio.pitch = Random.Range(0.5f, 1.5f);

        _audio.Play();

        SceneManager.LoadScene(1);

    }

}
