using UnityEngine;


public class ButtonEventHandler : MonoBehaviour, IVirtualButtonEventHandler
{
	
	
	private GameObject _modelDuck;
	private GameObject _modelCat;
	
	void Start() {
		// Search for all Children from this ImageTarget with type VirtualButtonBehaviour
		VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();
		for (int i = 0; i < vbs.Length; ++i) {
			// Register with the virtual buttons TrackableBehaviour
			vbs[i].RegisterEventHandler(this);
		}
		
		_modelDuck = transform.FindChild("goose").gameObject;
		_modelCat = transform.FindChild("cat").gameObject;
		
		_modelCat.SetActive(false);
	}
	
	/// <summary>
	/// Called when the virtual button has just been pressed:
	/// </summary>
	public void OnButtonPressed(VirtualButtonAbstractBehaviour vb) { 
		
		switch (vb.VirtualButtonName) {
		case "btnDuck":
			_modelCat.SetActive (false);
			_modelDuck.SetActive (true);
			break;
		case "btnCat":
			_modelCat.SetActive (true);
			_modelDuck.SetActive (false);
			break;
		default:
			throw new UnityException ("Button not supported: " + vb.VirtualButtonName);
			break;
		}
		
	}
	
	/// <summary>
	/// Called when the virtual button has just been released:
	/// </summary>
	public void OnButtonReleased(VirtualButtonAbstractBehaviour vb) { }
}