using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Space]
    [Title("Player controller settings")]
    [SerializeField]
    PlayerController playerController;
    [Tooltip("bounds for player movement in the X axis (how far can the player go to the left and right)")]
    [SerializeField] float bounds;

    [Space]
    [Title("Internal")]
    [SerializeField]
    GameObject ballPrefab;


    private void Awake()
    {
        InitializePlayerControllerValues();
    }

    private void InitializePlayerControllerValues()
    {
        playerController.Bounds = bounds;
    }

}
