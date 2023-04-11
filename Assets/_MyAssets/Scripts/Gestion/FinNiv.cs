using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using UnityEngine.SceneManagement;

public class FinNiv : MonoBehaviour
{
    //Attribut 
    private GestionJeu _gestionJeu;
    private Player _player;
    private int noScene;


    // Start is called before the first frame update
    void Start()
    {
        _gestionJeu = FindObjectOfType<GestionJeu>();
        _player = FindObjectOfType<Player>();
    }
    public int GetSceneNum() { return noScene; }

    //Termine le niveau et enregistre les temps 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            _player.FinPartie();
            noScene = SceneManager.GetActiveScene().buildIndex;
            if (noScene == 4)
            {
                _gestionJeu.FinNiveau();
                Debug.Log(_gestionJeu.GetMess() + " Temps final: " + _gestionJeu.GetTempTot() + " Nombre d'accrochage total: " + _gestionJeu.GetPoint() + " Pour un temps total avec penalités de: " + (_gestionJeu.GetTempTot() + _gestionJeu.GetPoint() )) ;
            }
            else
            {
                _gestionJeu.FinNiveau();
                SceneManager.LoadScene(noScene + 1);
            }
        }
    }

    
}
