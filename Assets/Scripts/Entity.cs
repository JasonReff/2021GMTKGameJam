using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public float movementSpeed;
    public CharacterOrEnemy characterOrEnemy;
    public enum CharacterOrEnemy
    {
        Character,
        Enemy
    }
}
