using UnityEngine;
using UnityEngine.InputSystem; // new input system

[RequireComponent(typeof(CharacterController))]
public class SimpleMove : MonoBehaviour
{
    public float speed = 2.2f;
    public float turnSpeed = 12f;
    public Transform cameraPivot;

    CharacterController cc;
    Animator anim;
    Vector3 vVel;
    const float g = -9.81f;

    void Awake() { cc = GetComponent<CharacterController>(); anim = GetComponentInChildren<Animator>(); }

    void Update()
    {
        // WASD / Arrow keys via new Input System
        float h = 0f, v = 0f;
        if (Keyboard.current != null)
        {
            h += Keyboard.current.aKey.isPressed ? -1 : 0;
            h += Keyboard.current.dKey.isPressed ? 1 : 0;
            v += Keyboard.current.sKey.isPressed ? -1 : 0;
            v += Keyboard.current.wKey.isPressed ? 1 : 0;

            // arrow keys
            h += Keyboard.current.leftArrowKey.isPressed ? -1 : 0;
            h += Keyboard.current.rightArrowKey.isPressed ? 1 : 0;
            v += Keyboard.current.downArrowKey.isPressed ? -1 : 0;
            v += Keyboard.current.upArrowKey.isPressed ? 1 : 0;
        }

        Vector3 input = new Vector3(h, 0, v).normalized;

        Vector3 f = cameraPivot ? Vector3.Scale(cameraPivot.forward, new Vector3(1, 0, 1)).normalized : Vector3.forward;
        Vector3 r = cameraPivot ? cameraPivot.right : Vector3.right;
        Vector3 dir = (f * input.z + r * input.x).normalized;

        if (dir.sqrMagnitude > 0.0001f)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), turnSpeed * Time.deltaTime);

        cc.Move(dir * speed * Time.deltaTime);

        if (cc.isGrounded && vVel.y < 0) vVel.y = -2f;
        vVel.y += g * Time.deltaTime;
        cc.Move(vVel * Time.deltaTime);

        if (anim) anim.SetFloat("Speed", input.magnitude, 0.1f, Time.deltaTime);
    }
}
