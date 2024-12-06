using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Assertions;

public class GameManeger : MonoBehaviour
{
    private Camera mainCamera_;

    //���C�t�֌W
    [SerializeField, Header("LifeUISetting")]
    //���C�t�Q�[�W
    private EnemyLifeBar EnemylifeBar_;
    //�ő�̗�
    [SerializeField]
    private float maxLife_ = 10;
    //���ݑ̗�
    private float life_;


    // Start is called before the first frame update
    void Start()
    {
        //�uMainCamera�v�Ƃ����^�O�����Q�[���I�u�W�F�N�g������
        GameObject mainCameraObject = GameObject.FindGameObjectWithTag("MainCamera");
        //NULL�o�Ȃ����Ƃ��m�F
        Assert.IsNotNull(mainCameraObject, "MainCamera��������܂���ł���");
        //Camera�R���|�[�l���g�����݂��A�擾�ł��邱�Ƃ��m�F
        Assert.IsTrue(mainCameraObject.TryGetComponent(out mainCamera_),"MainCamera��Camera�R���|�[�l���g������܂���");

        //�̗͂̏�����
        ResetLife();
    }

    // Update is called once per frame
    void Update()
    {
        //�N���b�N������_���[�W�𐶐�
        if (Input.GetMouseButtonDown(0))
        {
            Damage();
        }
    }

    private void Damage()
    {
        Damage(1);
    }


    //���C�t�̏�����
    private void ResetLife()
    {
        life_ = maxLife_;
        //UI�̍X�V
        UpdateLifeBar();
    }

    //���C�tUI�̍X�V
    private void UpdateLifeBar()
    {
        //�ő�̗͂ƌ��ݑ̗͂̊����ŉ����������o
        float lifeRatio = Mathf.Clamp01(life_ / maxLife_);
        //������LifeBar_�ւƓ`���AUI�ɔ��f���Ă��炤
        EnemylifeBar_.SetGaugeRatio(lifeRatio);
    }

    /// <summary>
    /// ���C�t�����炷
    /// </summary>
    /// <param name="point"></param>
    public void Damage(float point)
    {
        life_ -= point;
        //UI�̍X�V
        UpdateLifeBar();
    }
}
