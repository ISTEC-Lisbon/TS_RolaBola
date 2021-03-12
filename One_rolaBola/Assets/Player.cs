using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody _rb;
    public float Speed = 700;
    public float Salto = 120;
    private bool _hitChao = false;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Chao"))
        {
            _hitChao = true;
            Debug.Log(_hitChao);
        }
    }

    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("Chao"))
        {
            _hitChao = false;
            Debug.Log(_hitChao);
        }
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * Speed;
        float y = (_hitChao) ? Input.GetAxis("Jump") * Salto : 0;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * Speed;

        Vector3 forca = new Vector3(x, y, z);
        _rb.AddForce(forca);


        //rb.AddForce();
    }

}
