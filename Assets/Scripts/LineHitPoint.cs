using UnityEngine;
using System.Collections;

public class LineHitPoint : MonoBehaviour {

	public float lifeTime = 1f;

	private Active _active;
	private int _index;
	private bool _hit;
	private bool _signal = false;
	private Timer _timer;
	
	void Start () {
		_hit = false;
		_timer = GetComponent<Timer>();
		_active = Camera.main.GetComponent<Active>();
	}

	void Update(){
		if(isHit()){
			_timer.startStopWatch();
		} else {
			_timer.stopStopWatch();
		}
		float temp = _timer.getStopWatchTime();
		if(_timer.getStopWatchTime() >= lifeTime){
			_signal = true;
			switchColor(Color.green);
			_timer.resetStopWatch();
//			Debug.Log(_timer.getStopWatchTime());
		}
		colorSwitcher();
//		checkHits();
//		Debug.Log(getLHPIndex().ToString() + ": " + isHit());
//		Debug.Log(_timer.getStopWatchTime().ToString("0.00"));
	}

	public void hit(bool b){
		_hit = b;
	}

	public bool isHit(){
		return _hit;
	}

	public bool getSignal(){
		return _signal;
	}

	public void resetSignal(){
		_signal = false;
	}

	public void setLHPIndex(int i){
		_index = i;
	}

	public int getLHPIndex(){
		return _index;
	}

	private void switchColor(Color c){
		transform.renderer.material.color = c;
	}

	private void colorSwitcher(){
		if(_timer.getStopWatchTime() < lifeTime/3f)
			switchColor(Color.green);
		if(_timer.getStopWatchTime() >= lifeTime/3f && _timer.getStopWatchTime() <= (lifeTime * (2f/3f)))
			switchColor(Color.yellow);
		if(_timer.getStopWatchTime() > (lifeTime * (2f/3f)))
			switchColor(Color.red);
	}

	private void checkHits(){
		RaycastHit[] hits = Active._hits;
		if(hits != null && hits.Length > 0){
			bool c = false;
			foreach(RaycastHit phit in hits){
				LineHitPoint l = phit.transform.gameObject.GetComponent<LineHitPoint>();
				int a = GetComponent<LineHitPoint>().getLHPIndex();
				int b = 0;
				if(l != null)
					b = l.getLHPIndex();
				bool cond = l != null && a == b;
				if(cond){
					c = true;
					hit(c);
				}
			}
			if(!c)
				hit(c);
			} else {
			hit (false);
		}
		Active.resetHits();
	}
}
