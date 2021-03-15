using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControllerScript : MonoBehaviour
{
    private Text _txtScore;
    private int _score;
    private ControllerScript _instancia;

    private void Start()
    {
        if (_instancia != null) Destroy(gameObject);
        else
        {
            _instancia = this;
            DontDestroyOnLoad(this);

        }

        _txtScore = GameObject.Find("txtScore").GetComponent<Text>();

    }

    public void Scoring()
    {
        _score++;
        _txtScore.text = _score.ToString();
        if (_score >= 8)
        {
            SceneManager.LoadScene("EndGame", LoadSceneMode.Single);
        }
    }

}
