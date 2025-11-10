using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using System.Globalization;

[CreateAssetMenu(fileName = "PlayerMovement", menuName = "Scriptable Objects/PlayerMovement")]
public class PlayerMovement : ScriptableObject
{
    public TMP_Text scoreText;
    public int PlayerScore = 0;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            PlayerScore += 1;
            scoreText.SetText("Score: " + PlayerScore);
        }
    }

}