using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //publics
    [Header("Lerp")]
    public Transform target;
    public float lerpSpeed = 1f;

    public float speed = 1f;

    public string tagToCheck = "Enemy";
    public string tagToCheckEndLine = "EndLine";

    public GameObject endScreen;

    //privates
    private bool _canRun;
    private Vector3 _pos;

    void Update()
    {
        if (!_canRun) return;

        _pos = new Vector3(target.position.x, transform.position.y, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime);

        transform.Translate(transform.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == tagToCheck)
        {
            EndGame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == tagToCheckEndLine)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        _canRun = false;
        endScreen.SetActive(true);
    }

    public void StartToRun()
    {
        _canRun = true;
    }
}
