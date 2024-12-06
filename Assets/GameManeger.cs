using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Assertions;

public class GameManeger : MonoBehaviour
{
    private Camera mainCamera_;

    //ライフ関係
    [SerializeField, Header("LifeUISetting")]
    //ライフゲージ
    private EnemyLifeBar EnemylifeBar_;
    //最大体力
    [SerializeField]
    private float maxLife_ = 10;
    //現在体力
    private float life_;


    // Start is called before the first frame update
    void Start()
    {
        //「MainCamera」というタグを持つゲームオブジェクトを検索
        GameObject mainCameraObject = GameObject.FindGameObjectWithTag("MainCamera");
        //NULL出ないことを確認
        Assert.IsNotNull(mainCameraObject, "MainCameraが見つかりませんでした");
        //Cameraコンポーネントが存在し、取得できることを確認
        Assert.IsTrue(mainCameraObject.TryGetComponent(out mainCamera_),"MainCameraにCameraコンポーネントがありません");

        //体力の初期化
        ResetLife();
    }

    // Update is called once per frame
    void Update()
    {
        //クリックしたらダメージを生成
        if (Input.GetMouseButtonDown(0))
        {
            Damage();
        }
    }

    private void Damage()
    {
        Damage(1);
    }


    //ライフの初期化
    private void ResetLife()
    {
        life_ = maxLife_;
        //UIの更新
        UpdateLifeBar();
    }

    //ライフUIの更新
    private void UpdateLifeBar()
    {
        //最大体力と現在体力の割合で何割かを検出
        float lifeRatio = Mathf.Clamp01(life_ / maxLife_);
        //割合をLifeBar_へと伝え、UIに反映してもらう
        EnemylifeBar_.SetGaugeRatio(lifeRatio);
    }

    /// <summary>
    /// ライフを減らす
    /// </summary>
    /// <param name="point"></param>
    public void Damage(float point)
    {
        life_ -= point;
        //UIの更新
        UpdateLifeBar();
    }
}
