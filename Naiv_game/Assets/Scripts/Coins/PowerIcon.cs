using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerIcon : MonoBehaviour
{
    public Text _PowerText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateAmmoText(int _currentAmmo, int _maxAmmo)
    {
        _PowerText.text = _currentAmmo + "/" + _maxAmmo;
    }
}
