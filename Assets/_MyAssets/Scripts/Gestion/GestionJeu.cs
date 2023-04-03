using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionJeu : MonoBehaviour
{
    //Attributs
    private int _pointage;
    Player _tempsdebut;
    float _tempsdeduction;
    string _messageFinal = "";
    private Player _player;
    private float _tempTot = 0;
    private float _tempNiv;
    private int  _niv = 0;


    private int _accrochageNiveau1 = 0;  // Atribut qui conserve le nombre d'accrochage pour le niveau 1
    private float _tempsNiveau1 = 0.0f;  // Attribut qui conserve le temps pour le niveau 1

    private int _accrochageNiveau2 = 0;  // Atribut qui conserve le nombre d'accrochage pour le niveau 1
    private float _tempsNiveau2 = 0.0f;  // Attribut qui conserve le temps pour le niveau 1

    private int _accrochageNiveau3 = 0;  // Atribut qui conserve le nombre d'accrochage pour le niveau 1
    private float _tempsNiveau3 = 0.0f;  // Attribut qui conserve le temps pour le niveau 1




    private void Awake()
    {
        // Vérifie si un gameObject GestionJeu est déjà présent sur la scène si oui
        // on détruit celui qui vient d'être ajouté. Sinon on le conserve pour le 
        // scène suivante.
        int nbGestionJeu = FindObjectsOfType<GestionJeu>().Length;
        if (nbGestionJeu > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Instructions()
    {
        _pointage = 0;
        Debug.Log("*** Course a obstacle ***");
        Debug.Log("Atteind la fin du parkour le plus vite possible!");
        Debug.Log("Chaque obstacle touché entraine une pénalité");
       
    }
    void Start()
    {
        Instructions();
        _tempsdebut = FindObjectOfType<Player>();
        _player = FindObjectOfType<Player>();
        _tempsdeduction = _tempsdebut.getTempsdebut();
    }


    // Accesseur qui retourne le temps pour le niveau 1
    public float GetTempsNiv1()
    {
        return _tempsNiveau1;
    }

    // Accesseur qui retourne le nombre d'accrochages pour le niveau 1
    public int GetAccrochagesNiv1()
    {
        return _accrochageNiveau1;
    }

    // Méthode qui reçoit les valeurs pour le niveau 1 et qui modifie les attributs respectifs
    public void SetNiveau1(int accrochages, float tempsNiv1)
    {
        _accrochageNiveau1 = accrochages;
        _tempsNiveau1 = tempsNiv1;
    }


    // Accesseur qui retourne le temps pour le niveau 1
    public float GetTempsNiv2()
    {
        return _tempsNiveau2;
    }

    // Accesseur qui retourne le nombre d'accrochages pour le niveau 1
    public int GetAccrochagesNiv2()
    {
        return _accrochageNiveau2;
    }

    // Méthode qui reçoit les valeurs pour le niveau 1 et qui modifie les attributs respectifs
    public void SetNiveau2(int accrochages, float tempsNiv1)
    {
        _accrochageNiveau2 = accrochages;
        _tempsNiveau2 = tempsNiv1;
    }

    // Accesseur qui retourne le temps pour le niveau 1
    public float GetTempsNiv3()
    {
        return _tempsNiveau3;
    }

    // Accesseur qui retourne le nombre d'accrochages pour le niveau 1
    public int GetAccrochagesNiv3()
    {
        return _accrochageNiveau3;
    }

    // Méthode qui reçoit les valeurs pour le niveau 1 et qui modifie les attributs respectifs
    public void SetNiveau3(int accrochages, float tempsNiv1)
    {
        _accrochageNiveau3 = accrochages;
        _tempsNiveau3 = tempsNiv1;
    }

    public void FinNiveau()
    {
        float _tempNiv;
        int accrochage;
        _niv++; 
        _tempNiv = (Time.time - _player.getTempsdebut());
       _tempTot += GetTempNiv();
        accrochage = GetPoint();
        if(_niv ==1)
        {
            _tempsNiveau1= _tempNiv;
            _accrochageNiveau1= accrochage;
            _tempTot += _tempsNiveau1;
            _messageFinal += "Pour le niveau " + _niv + " le temps est de: " + _tempsNiveau1 + " et le nombre d'accrochage est de: " + _accrochageNiveau1;
        }
        if(_niv == 2)
        {
            _tempsNiveau2=(_tempNiv - _tempsNiveau1);
            _accrochageNiveau2 = (accrochage - _accrochageNiveau1);
            _tempTot += _tempsNiveau2;
            _messageFinal += "Pour le niveau " + _niv + " le temps est de: " + _tempsNiveau2 + " et le nombre d'accrochage est de: " + _accrochageNiveau2;
        }
        if(_niv == 3)
        {
            _tempsNiveau3 = (_tempNiv - (_tempsNiveau2 + _tempsNiveau1));
            _accrochageNiveau3 = (accrochage - (_accrochageNiveau2 + _accrochageNiveau1));
            _tempTot += _tempsNiveau3;
            _messageFinal += "Pour le niveau " + _niv + " le temps est de: " + _tempsNiveau3 + " et le nombre d'accrochage est de: " + _accrochageNiveau3;

        }
    }

    public void AugmenterPointage()
    {
        _pointage++;
        Debug.Log("Nombre d'accrochage : " + _pointage);
    }

    public int GetPoint() { return _pointage; } //Pour aller chercher les points 

    public float GetTempNiv() { return _tempNiv; }

    public float GetTemp() { return _tempsdeduction;} // Pour aller chercher le temps reductions
  
    public string GetMess() { return _messageFinal; } // va chercher le message finale

    public float GetTempTot() { return _tempTot; } 
    
}
