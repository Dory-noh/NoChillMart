using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController cc;
    private Animator animator;

    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float gravity = -9.81f;

    private Vector3 velocity;
    private Vector3 moveDirection;

    private int hashPosX = Animator.StringToHash("PosX");
    private int hashPosY = Animator.StringToHash("PosY");
    private int hashSpeed = Animator.StringToHash("Speed");

    void Start()
    {
        cc = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        // WASD �Է� �ޱ�
        float x = Input.GetAxis("Horizontal"); // A, D
        float z = Input.GetAxis("Vertical");   // W, S
        bool IsRun = Input.GetKeyDown(KeyCode.LeftShift);
        //animator.SetFloat(hashPosX, x);
        //animator.SetFloat(hashPosY, z);

        float turnSpeed = 100f;
        transform.Rotate(Vector3.up * x * turnSpeed * Time.deltaTime);
        moveSpeed = (z == 0) ? 0 : (IsRun ? 5f : 3f);
        animator.SetFloat(hashSpeed, moveSpeed);

        // ���� ���
        moveDirection = transform.forward * z;

        // �߷� ����
        if (cc.isGrounded)
        {
            if (velocity.y < 0)
                velocity.y = -2f; // ���� ���̴� �뵵
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }

        // �̵� ����
        Vector3 finalMove = moveDirection * moveSpeed + velocity;
        cc.Move(finalMove * Time.deltaTime);
    }
}
