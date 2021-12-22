using UnityEngine.SceneManagement;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("FantasticWorld");
    }
}
