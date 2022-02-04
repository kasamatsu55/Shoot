using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    private GameManager gm; //最初にcubeがいないのでpublicは使用できない。publicなsetterを用意してセットする

    void OnCollisionEnter(Collision coll) //ものがぶつかったとき
    {
        if(coll.gameObject.tag == "Bullet")
        {
            gm.SetScore(gm.GetScore() + 1); //現在の点数に+1してセットする
            //プロパティを使用すれば、「gm.Score+1」でOK
            Destroy(gameObject, 0.1f); //第二引数後に消す（余韻、効果音などを考慮）
        }

        if(coll.gameObject.tag == "Floor") //地面に触れたらゲームオーバー
        {
            gm.SetMsg("GameOver");
        }
    }

    public void SetGameManager(GameManager gm) //setter
    {
        this.gm = gm; //管理できるようになる
    }
}
