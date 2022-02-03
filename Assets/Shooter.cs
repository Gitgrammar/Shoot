using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour// 継承は:
{
	public GameObject prefab; //登録可能になる。

	void Update()//最初のUPDATEの直前に動くのがstart Uは大文字。これで１秒間に６０回動くメソッド
	{
		if (Input.GetMouseButtonDown(0))//入力関係はinputクラスgetmouseButtonDown 0が左クリック1がオプションクリック
		{
			//引数一つでInstantiate
			GameObject obj = Instantiate(prefab);//instantiate従来は３つだった何をどこにどの向きで。　引数１個でもできる。これでヒエラルキーに登場する。
			//親要素設定（今回はカメラ)
			obj.transform.parent = transform;//作ったものの親を決めたい。いきなりトランスフォームなのでscriptがアタッチされたゲームオブジェクトここではカメラ　親はカメラ。子は弾丸
			//親要素からのオフセットは0
			obj.transform.localPosition = Vector3.zero;//ずれはゼロ　。カメラと同じ位置に弾丸が移動する。
			//メインカメラからマウスクリックした地点にrayを飛ばす
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//rayは光線。ｘray線などを考えるといい。camera.mainはmaincameraタグが付いたものという意味。逆になっているがこういう仕様。.
			//SreenPointRay inputmouseposition から光線をつける。
			//rayの方向を長さ1にして dirに代入 
			Vector3 dir = ray.direction.normalized;//ray.dirctionを取って上記のものをベクトルに変換。normalize は１が入る速さをどこも一定にする。

			//生成したObjのrigidbodyを取得し、速度をdir方向に与える
			//obj.GetComponent<Rigidbody>().velocity = dir * 100.0f;//弾丸のrigidbodycomponentにアクセスする。テスト出る。.velocityはプロパティ代入して使う。
			obj.GetComponent<Rigidbody>().AddForce(dir * 100f,ForceMode.Impulse);// forcemodeつけないと遅すぎる。　addforce()はメソッド。()があるためメソッド。dir はdirection方向
		}

	}
}
