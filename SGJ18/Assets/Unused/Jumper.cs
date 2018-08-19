using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class Jumper : MonoBehaviour
{
    public GameObject shadowObj;
    public AnimationClip jumpAnimation;
    public float jumpDist;

    Animator anim;
    int jumpHash = Animator.StringToHash("Jump");
    float jumpDuration;
    float jumpTime;
    float moveFraction;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        jumpDuration = jumpAnimation.length;
        moveFraction = jumpDist / jumpDuration;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger(jumpHash);
        }
    }

    public void ShowShadow()
    {
        shadowObj.SetActive(true);
    }

    public void HideShadow()
    {
        shadowObj.SetActive(false);
    }

    public void JumpMove()
    {
        jumpTime = jumpDuration;
        IEnumerator coroutine = MoveOverTime();
        StartCoroutine(coroutine);
    }

    IEnumerator MoveOverTime()
    {
        while (jumpTime > 0f)
        {
            transform.position += Vector3.right * moveFraction * Time.deltaTime;
            jumpTime -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
}
