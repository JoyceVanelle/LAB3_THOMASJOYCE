using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AffichageFin: MonoBehaviour
{
    [SerializeField] private TMP_Text _txtTempsTotal = default;
    [SerializeField] private TMP_Text _txtAccorchagesTotal = default;
    [SerializeField] private TMP_Text _txtPointageTotal = default;
    private GestionJeu _gestionJeu;
    void Start()
    {

        _gestionJeu = FindObjectOfType<GestionJeu>();
        _txtTempsTotal.text = "Temps Total : " + _gestionJeu.GetTempTot().ToString("f2") + " sec.";
        _txtAccorchagesTotal.text = "Nombres d'accrochages : " + _gestionJeu.GetPoint().ToString();
        float pointageTotal = _gestionJeu.GetTempTot() + _gestionJeu.GetPoint();
        _txtPointageTotal.text = "Pointage Final : " + pointageTotal.ToString("f2") + " sec.";
    }

    // Update is called once per frame
   
}
