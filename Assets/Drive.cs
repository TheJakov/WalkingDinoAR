using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Drive : MonoBehaviour
{
    float speed = 1.5F;
    float rotationSpeed = 50.0F;

    Animator animator;

    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    void Update()
    {
        float translation = CrossPlatformInputManager.GetAxis("Vertical") * speed;
        float rotation = CrossPlatformInputManager.GetAxis("Horizontal") * rotationSpeed;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        if (translation > 0)
        {
            animator.SetBool("isRunning", true);
            animator.SetFloat("speed", 1.0f);
        }
        else if (translation < 0)
        {
            animator.SetBool("isRunning", true);
            animator.SetFloat("speed", -1.0f);
        }
        else
            animator.SetBool("isRunning", false);

        if (CrossPlatformInputManager.GetButtonDown("Jump"))
            animator.SetTrigger("jump");
    }
}
