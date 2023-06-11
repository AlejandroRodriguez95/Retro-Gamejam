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
    [Tooltip("Default speed for player paddle in the x-axis")]
    [SerializeField] float speed;
    [Tooltip("Bounds for player movement in the x-axis (how far can the player go to the left and right)")]
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
        playerController.Speed = speed;
    }

}
