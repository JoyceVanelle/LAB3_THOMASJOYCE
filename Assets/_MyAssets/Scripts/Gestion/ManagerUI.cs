using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManagerUI : MonoBehaviour
{

    [SerializeField] private TMP_Text _txtAccrochages = default;
    [SerializeField] private TMP_Text _txtTemps = default;
    [SerializeField] private GameObject _menuPause = default;
   
    private bool _enpause = false;
    private bool _debutJeu = false;
    private float debNiv = 0;


    private bool _enPause;
    private GestionJeu _gestionJeu;


    void Start()
    {
        _gestionJeu = FindObjectOfType<GestionJeu>();
        _txtAccrochages.text = "Accrochages : " + _gestionJeu.GetPoint();
        Time.timeScale = 1;
        _enPause = false;
    }


    private void Update()
    {
        GestionPause();
        if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Vertical") > 0 || Input.GetAxis("Vertical") < 0 || Input.GetAxis("Horizontal") < 0 && _debutJeu)
        {
            debNiv = Time.time;
            _debutJeu = true;
            Debug.Log("Niveau Commencer");
            
        }
        if (_debutJeu)
        {
            float temps = (Time.time - _gestionJeu.GetTemp()) - debNiv;
            _txtTemps.text = "Temps : " + temps.ToString("f2");
        }
    }

    private void GestionPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_enPause)
        {
            _menuPause.SetActive(true);
            Time.timeScale = 0;
            _enPause = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && _enPause)
        {
           // EnleverPause();
        }
    }

    public void ChangerPointage(int p_pointage)
    {
        _txtAccrochages.text = "Accrochages : " + p_pointage.ToString();
    }

    public void enleverpause()
    {
       _menuPause.SetActive(false);
       Time.timeScale = 1;
        _enpause = false;
    }
}
