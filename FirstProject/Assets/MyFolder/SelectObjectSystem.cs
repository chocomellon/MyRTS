using UnityEngine;
using System.Collections;

public class SelectObjectSystem : MonoBehaviour
{

    public Vector3 startPos;
    public Vector3 endPos;
    public float s_x;//始点x座標
    public float s_y;//始点ｙ座標
    public float e_x;//終点x座標
    public float e_y;//終点y座標

    public GameObject[] gameobject;//デモ用のオブジェクト格納

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        click();
    }

    void click()
    {

        //左クリックしたときと離した時とで疑似的なドラッグ操作にしてます。
        //左クリックしたとき
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;//クリックした位置
            startPos.z = 10f;//マウス座標の奥行の設定
            startPos = Camera.main.ScreenToWorldPoint(startPos);//スクリーン座標をワールド座標に
                                                                //↓左を離した時
        }
        else if (Input.GetMouseButtonUp(0))
        {
            endPos = Input.mousePosition;
            endPos.z = 10f;
            endPos = Camera.main.ScreenToWorldPoint(endPos);
            unitpositionculiculate();//オブジェクトの位置を判定するメソッド
        }

    }

    void unitpositionculiculate()
    {

        s_x = startPos.x;
        s_y = startPos.y;
        e_x = endPos.x;
        e_y = endPos.y;
        //初期の始点と終点のX座標で、始点が終点よりも大きかったら終点の座標と入れ替え
        if (startPos.x > endPos.x)
        {
            s_x = endPos.x;
            e_x = startPos.x;
        }
        //初期の始点と終点のY座標で、始点が終点よりも大きかったら終点の座標と入れ替え
        if (startPos.y > endPos.y)
        {
            s_y = endPos.y;
            e_y = startPos.y;
        }
        //for文で判定を行う
        for (int i = 0; i < 3; i++)
        {
            Vector3 posi = gameobject[i].transform.position;
            //条件式
            if (s_x <= posi.x && e_x >= posi.x && s_y <= posi.y && e_y >= posi.y)
            {
                Debug.Log("範囲内にいます" + gameobject[i].name);
            }
        }

    }
}