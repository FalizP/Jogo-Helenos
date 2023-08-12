using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingMiniGame : MonoBehaviour
{
    [SerializeField] Transform topPivot;
    [SerializeField] Transform bottomPivot;


    private void Start()
    {
        Resize();
    }

    private void Update()
    {
        if (pause) return;

        Fish();
        Hook();
        ProgressCheck();
    }


    private void Resize()
    {
        Bounds b = hookSpriteRenderer.bounds;
        float ySize = b.size.y;
        Vector3 ls = hook.localScale;
        float distance = Vector3.Distance(topPivot.position, bottomPivot.position);
        ls.y = (distance / ySize * hookSize);
        hook.localScale = ls;
    }
    
    bool pause = false;


    [SerializeField] Transform fish;
    float fishPosition;
    float fishDestinantion;
    float fishTimer;
    [SerializeField] float timerMultiplicator = 3f;
    float fishSpeed;
    [SerializeField] float smoothMotion = 1f;
    void Fish()
    {
        fishTimer -= Time.deltaTime;
        if (fishTimer < 0f)
        {
            fishTimer = UnityEngine.Random.value * timerMultiplicator;

            fishDestinantion = UnityEngine.Random.value;
        }

        fishPosition = Mathf.SmoothDamp(fishPosition, fishDestinantion, ref fishSpeed, smoothMotion);
        fish.position = Vector3.Lerp(bottomPivot.position, topPivot.position, fishPosition);
    }


    [SerializeField] Transform hook;
    float hookPosition;
    [SerializeField] float hookSize = 0.1f;
    [SerializeField] float hookPower = 0.5f;
    float hookProgress;
    float hookPullVelocity;
    [SerializeField] float hookPullPower = 0.01f;
    [SerializeField] float hookGravityPower = 0.005f;
    [SerializeField] float hookProgressDegradationPower = 0.1f;
    [SerializeField] SpriteRenderer hookSpriteRenderer;
    void Hook()
    {
        if (Input.GetMouseButton(0))
        {
            hookPullVelocity += hookPullPower * Time.deltaTime;
        }
           
        hookPullVelocity -= hookGravityPower * Time.deltaTime;
        hookPosition += hookPullVelocity;

        if ((hookPosition - hookSize / 2 <= 0f) && (hookPullVelocity < 0f))
        {
            hookPullVelocity = 0f;
        }
        if ((hookPosition + hookSize / 2 >= 1f) && (hookPullVelocity > 0f))
        {
            hookPullVelocity = 0f;
        }

        hookPosition = Mathf.Clamp(hookPosition, hookSize / 2, 1 - hookSize / 2);
        hook.position = Vector3.Lerp(bottomPivot.position, topPivot.position, hookPosition);
    }

    [SerializeField] Transform progressBarContainer;
    void ProgressCheck()
    {
        Vector3 ls = progressBarContainer.localScale;
        ls.y = hookProgress;
        progressBarContainer.localScale = ls;

        float min = hookPosition - hookSize / 2;
        float max = hookPosition + hookSize / 2;

        if ((min < fishPosition) && (fishPosition < max))
        {
            hookProgress += hookPower * Time.deltaTime;
        }
        else
        {
            hookProgress -= hookProgressDegradationPower * Time.deltaTime;
            failTimer -= Time.deltaTime;
            if (failTimer < 0f)
            {
                Lose();
            }
        }

        if (hookProgress >= 1f)
        {
            Win();
        }
        hookProgress = Mathf.Clamp(hookProgress, 0f, 1f);
    }

    void Win()
    {
        pause = true;
        Debug.Log("Você pescou o peixe!");
    }

    [SerializeField] float failTimer = 10f;
    void Lose()
    {
        pause = true;
        Debug.Log("Você perdeu o peixe!");
    }
}
