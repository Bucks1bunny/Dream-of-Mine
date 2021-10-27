using UnityEngine;
using System.Collections;
using UnityEngine.Rendering.PostProcessing;

public class AnimtionTrigger : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private GameObject lightSource;
    [SerializeField]
    private GameObject room;
    [SerializeField]
    private PostProcessVolume pointLight;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(RoomDisappear());
        }
    }
    IEnumerator RoomDisappear()
    {
        for (int i = 0; pointLight.weight >= i; pointLight.weight-=.01f)
        {
            yield return new WaitForSeconds(.01f);
        }
        Destroy(lightSource);
        yield return new WaitForSeconds(1);
        anim.enabled = true;
        RenderSettings.fog = true;
        for (float i = .1f; RenderSettings.fogDensity <= i; RenderSettings.fogDensity += .01f)
        {
            yield return new WaitForSeconds(.01f);
        }
        yield return new WaitForSeconds(.4f);
        Destroy(room);
       

    }
}
