using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{
    public bool enableSelectPlayer;

    public enum Player {Man, Girl};
    public Player playerSelected;

    public Animator animator;
    public SpriteRenderer spriteRenderer;

    public RuntimeAnimatorController[] playersController;
    public Sprite[] playersRenderer;

    void Start()
    {
        if (!enableSelectPlayer)
        {
            ChangePlayerSkin();
        } else 
        {
            switch (playerSelected)
            {
                case Player.Man:
                    spriteRenderer.sprite = playersRenderer[0];
                    animator.runtimeAnimatorController = playersController[0];
                    break;
                case Player.Girl:
                    spriteRenderer.sprite = playersRenderer[1];
                    animator.runtimeAnimatorController = playersController[1];
                    break;
                default:
                    break;
            }
        }
    }

    public void ChangePlayerSkin()
    {
        switch (PlayerPrefs.GetString("PlayerSelected"))
            {
                case "Man":
                    spriteRenderer.sprite = playersRenderer[0];
                    animator.runtimeAnimatorController = playersController[0];
                    break;
                case "Girl":
                    spriteRenderer.sprite = playersRenderer[1];
                    animator.runtimeAnimatorController = playersController[1];
                    break;
                default:
                    break;
            }
    }
}
