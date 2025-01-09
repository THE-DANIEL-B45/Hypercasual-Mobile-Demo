using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableBase : MonoBehaviour
{
    public string compareTag = "Player";
    public ParticleSystem myParticleSystem;
    public float timeToHide = 3f;
    public GameObject graphicItem;
    bool once;

    [Header("Sounds")]
    public AudioSource audioSource;

    private void Awake()
    {
        //if (myParticleSystem != null) myParticleSystem.transform.SetParent(null);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag(compareTag) && !once)
        {
            once = true;
            Collect();
        }
    }

    protected virtual void Collect()
    {
        if (graphicItem != null)graphicItem.SetActive(false);
        Invoke(nameof(HideObject), timeToHide);
        OnCollect();
    }

    private void HideObject()
    {
        gameObject.SetActive(false);
    }

    protected virtual void OnCollect()
    {
        if (myParticleSystem != null)
        {
            myParticleSystem.Play();
        }
        if(audioSource != null)
        {
            audioSource.Play();
        }
    }
}
