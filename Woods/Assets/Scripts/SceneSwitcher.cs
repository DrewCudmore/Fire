using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string sceneToSwitchTo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Car")
        {
            SceneManager.LoadScene(sceneToSwitchTo);
        }
    }
}
