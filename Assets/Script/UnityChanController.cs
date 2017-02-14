using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour {
	Animator animator; //アニメーションするためのコンポーネントを入れる
	Rigidbody2D rigid2D; //Unityちゃんを移動させるコンポーネントを入れる
	private float groundLevel=-3.0f; //地面の位置
	private float dump=0.8f; //ジャンプの減衰
	float jumpVelocity=20; //ジャンプの速度
	private float deadLine=-9;



	// Use this for initialization
	void Start () {
		this.animator = GetComponent<Animator> (); //アニメータのコンポーネントを取得する
		this.rigid2D=GetComponent<Rigidbody2D>(); //Rigidbody2Dのコンポーネントを取得する

	}
	
	// Update is called once per frame
	void Update () {
		//走るアニメーションを再生するために、Animatorのパラメータを調整
		this.animator.SetFloat ("Horizontal", 1);
		//着地しているかを確認
		bool isGround = (transform.position.y > this.groundLevel) ? false : true;
		this.animator.SetBool ("isGround", isGround);
		//ジャンプしている時はボリュームを0にする
		GetComponent<AudioSource> ().volume = (isGround) ? 1 : 0;

		//着地状態でクリックされた場合
		if (Input.GetMouseButtonDown (0) && isGround) {
			//上方向の力を加える
			this.rigid2D.velocity = new Vector2 (0, this.jumpVelocity);
		}
		//クリックをやめたら上方向へ速度を減速する
		if (Input.GetMouseButton (0) == false) {
			if (this.rigid2D.velocity.y > 0) {
				this.rigid2D.velocity *= this.dump;
			}
		}
		//デッドラインを超えたらゲームオーバー
		if (transform.position.x < this.deadLine) {
			//UIControllerのGameOver関数を呼び出して画面に表示
			GameObject.Find ("Canvas").GetComponent<UIController> ().GameOver ();
			//Unityちゃんを破棄する
			Destroy (gameObject);
		}
	}
	//衝突時に呼ばれる関数
		void OnCollisionEnter(Collision other){
		if(other.gameObject.tag=="boxTag"){
			Debug.Log ("donai");
			GetComponent<AudioSource> ().volume = 0;
			
   }
  }
}