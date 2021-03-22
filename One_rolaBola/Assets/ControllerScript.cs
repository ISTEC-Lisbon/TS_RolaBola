using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControllerScript : MonoBehaviour
{
    private GameObject _painelFim, _painelResumo;
    private Text _txtScore, _txtTempo;
    private int _score;
    private float _tempo;
    private bool _isPlaying;
    private static ControllerScript _instancia;

    private void Awake()
    {
        //Singleton
        if (_instancia != null) Destroy(gameObject);
        else
        {
            _instancia = this;
            DontDestroyOnLoad(this);

        }
    }

    private void Start()
    {
        _tempo = 0;
        
        
        _isPlaying = true;
        _txtScore = GameObject.Find("txtScore").GetComponent<Text>();
        _txtTempo = GameObject.Find("txtTempo").GetComponent<Text>();
        _painelFim = DevolvePainel("painelFim");
        _painelResumo = DevolvePainel("_painelResumo");


        StartCoroutine(Relogio());
    }

    private void Update()
    {
        _tempo += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isPlaying)
            {
                Pausa();
            }
            else
            {
                Resumo();
            }
        }

    }

    public void Reload()
    {
        _tempo = 0;
        _score = 0;
        _painelResumo.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        Time.timeScale = 1f;
        _isPlaying = true;
    }

    public void Resumo()
    {
        _painelResumo.SetActive(false);
        Time.timeScale = 1f;
        _isPlaying = true;
    }

    public void Pausa()
    {
        _painelResumo.SetActive(true);
        Time.timeScale = 0f;
        _isPlaying = false;
    }



    public void Sair()
    {
#if UNITY_EDITOR //se estiver em modo de ediçao faz este
        UnityEditor.EditorApplication.isPlaying = false;
#else
Application.Quit();
#endif

    }

    public GameObject DevolvePainel(string nome)
    {
        Transform[] trs = (gameObject.GetComponentsInChildren<Transform>(true));

        foreach (Transform t in trs)
        {
            if (t.name == nome) return t.gameObject;
        }

        return null;
    }


    IEnumerator Relogio()
    {
        for (; ; ) //um for infinito (☉_☉)
        {
            yield return new WaitForSeconds(0.1f);
            _txtTempo.text = _tempo.ToString("## 'segundo(s)'");
        }
    }




    public void Scoring()
    {
        _score++;
        _txtScore.text = _score.ToString();
        if (_score >= 8)
        {
            _tempo = 0;
            SceneManager.LoadScene("EndGame", LoadSceneMode.Single);
            if (_painelFim != null) _painelFim.SetActive(true);
            Time.timeScale = 0f;
        }
    }

}
