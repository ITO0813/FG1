using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Slider))]
public class EnemyLifeBar : MonoBehaviour
{
    //Slider�̊���
    private float ratio_;

    //Slider�R���|�[�l���g
    private Slider slider_;

    private void Awake()
    {
        //Slider�R���|�[�l���g
        slider_ = GetComponent<Slider>();
    }

    //Slider�̊�����ݒ�
    public void SetGaugeRatio(float ratio)
    {
        //0�`1�͈̔͂Ő؂�l�߂�
        ratio_ = Mathf.Clamp01(ratio);
        //UI�ɔ��f
        slider_.value = ratio_;
    }

}
