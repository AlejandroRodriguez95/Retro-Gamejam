using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Space]
    [Title("Player Controller Settings")]
    [SerializeField]
    PlayerController playerController;

    [Space]
    [Title("Internal")]
    [SerializeField]
    GameObject ballPrefab;

}
