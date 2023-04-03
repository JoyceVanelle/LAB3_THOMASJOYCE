using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Attributs 
    [SerializeField] private float _vitesse = 250;
    //private EndGame _endGame;
    private Rigidbody _rb;
    private bool _debutJeu = true;
    private float _tempsdebut;

    // Start is called before the first frame update
    private void Start()
    {
        //Position de depart du joueur
        //this.transform.position = new Vector3(-26f, 0.51f, -26f); //this. est facultatif, mais on va le laiiser lol
       // _endGame = FindObjectOfType<EndGame>();
        _rb = GetComponent<Rigidbody>();
    }
    public float getTempsdebut()
    {
        return _tempsdebut;
    }


    // Update is called once per frame
    private void FixedUpdate()
    {
        MouvementJoueur();
    }

    public void FinPartie()
    {
        this.gameObject.SetActive(false); 
    }

    private void MouvementJoueur()
    {
        if (_debutJeu == true && (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Vertical") > 0))
        {
        
            _tempsdebut = Time.time;
            _debutJeu = false;
            Debug.Log("le temps de deduction est " + _tempsdebut);
        }
        float positionX = Input.GetAxis("Horizontal");
        float positionZ = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(positionX, 0f, positionZ);
        _rb.velocity = direction * Time.fixedDeltaTime * _vitesse;

        if(direction != Vector3.zero)
        {
            transform.forward = direction;
        }
    }
}
