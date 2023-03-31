using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virage : MonoBehaviour
{
    private Vector3 v = new Vector3(0,180f,0);
    [SerializeField] private GameObject _voit = default;
    private Transform tr;

    private void Start()
    {
        tr = _voit.GetComponent<Transform>();
    }

    private void OnTriggerEnter(Collider other)
    {
        tr.Rotate(v, Space.Self);
    }
}
