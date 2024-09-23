using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Yut yut;

    void Start()
    {
        yut = gameObject.AddComponent<Yut>();
    }

    public void OnRollButtonClicked()
    {
        yut.Roll();
    }
}