using UnityEngine;
using System.Collections;

public class LineHitPoint : MonoBehaviour {

	public float lifeTime = 1f;

	protected Active _active;
	protected int _index;
	protected bool _hit;
	protected bool _signal = false;
	protected Timer _timer;
	
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
//		if(_timer.getStopWatchTime() >= lifeTime){
//			_signal = true;
//			switchColor(Color.green);
//			_timer.resetStopWatch();
//		}
//		colorSwitcher();
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

	protected void switchColor(Color c){
		transform.renderer.material.color = c;
	}

	protected void colorSwitcher(){
		if(_timer.getStopWatchTime() < lifeTime/3f)
			switchColor(Color.green);
		if(_timer.getStopWatchTime() >= lifeTime/3f && _timer.getStopWatchTime() <= (lifeTime * (2f/3f)))
			switchColor(Color.yellow);
		if(_timer.getStopWatchTime() > (lifeTime * (2f/3f)))
			switchColor(Color.red);
	}

	protected void checkHits(){
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
