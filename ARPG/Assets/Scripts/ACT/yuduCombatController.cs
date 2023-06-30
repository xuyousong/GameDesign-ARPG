using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ACT.Combat;

public class yuduCombatController : BasicCombatModel
{
    //Speed
    [SerializeField, Header("�����ƶ��ٶȱ���"), Range(.1f, 10f)]
    private float attackMoveMult;

    //���
    [SerializeField, Header("������")] private Transform detectionCenter;
    [SerializeField] private float detectionRang;

    //����
    private Collider[] detectionedTarget = new Collider[1];

    private void Update()
    {
        PlayerAttackAction();
        DetectionTarget();
        ActionMotion();
    }

    private void PlayerAttackAction()
    {
        if (InputController.LAtk)
        {
            animator.SetTrigger(lAtkID);

        }
    }






    private void ActionMotion()
    {
        if (animator.CheckAnimationTag("Attack"))
        {
            MovementBase.MoveInterface(transform.forward, animator.GetFloat(animationMoveID) * attackMoveMult, true);
        }
    }

    #region �������

    /// <summary>
    /// ����״̬�Ƿ������Զ���������
    /// </summary>
    /// <returns></returns>
    private bool CanAttackLockOn()
    {
        if (animator.CheckAnimationTag("Attack"))
        {
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.75f)
            {
                return true;
            }
        }
        return false;
    }


    private void DetectionTarget()
    {
        int targetCount = Physics.OverlapSphereNonAlloc(detectionCenter.position, detectionRang, detectionedTarget,
            EnemyLayerMask);

        //�������ܲ���
    }

    #endregion
}
