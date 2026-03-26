using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    
    public void Play() {
        AudioManager.instance.PlaySFX(AudioManager.instance.buttonClick);
        AudioManager.instance.PlayGame();
    }

    public void Quit () {
        AudioManager.instance.PlaySFX(AudioManager.instance.buttonClick);
        Application.Quit();
    }
}
