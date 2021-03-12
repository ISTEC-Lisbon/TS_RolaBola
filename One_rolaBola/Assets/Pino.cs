using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pino : MonoBehaviour
{
    private AudioSource som;

    // Start is called before the first frame update
    void Start()
    {
        som = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Ja Fostes");
            som.Play();
            Destroy(transform.gameObject, 0.5f);
        }
    }


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 15));
    }
}
