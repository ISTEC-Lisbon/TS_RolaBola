using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pino : MonoBehaviour
{
    private AudioSource som;

    private ControllerScript _controllerScript;
    private bool _isDead;

    // Start is called before the first frame update
    void Start()
    {
        som = GetComponent<AudioSource>();
        _controllerScript = GameObject.Find("Controller").GetComponent<ControllerScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!_isDead)
            {
                _isDead = true;
                Debug.Log("Ja Fostes");
                som.Play();
                Destroy(transform.gameObject, 0.5f);
                _controllerScript.Scoring();
            }

        }
    }


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 15));
    }
}
