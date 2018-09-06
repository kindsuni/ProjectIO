using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(InputField))]
public class TabBetween : MonoBehaviour {

    public InputField nextField;
    InputField myfield;

	// Use this for initialization
	void Start () {
        if(nextField == null)
        {
            Destroy(this);
            return;
        }
        myfield = GetComponent<InputField>();
	}
	
	// Update is called once per frame
	void Update () {
		if(myfield.isFocused && Input.GetKeyDown(KeyCode.Tab))
        {
            nextField.ActivateInputField();
        }
	}
}
