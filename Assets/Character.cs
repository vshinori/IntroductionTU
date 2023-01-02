using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    Health _health;
    MyVector3 _position;
    private string _age;

    private void Start()
    {
        _health = new Health();
    }

}
