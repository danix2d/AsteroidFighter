using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IntVariableEvent", menuName = "Asteroid_Fighter/SOVariables/IntVariableEvent", order = 0)]
public class IntVariableEvent : ScriptableObject
{
    public int init;
    [SerializeField] private int _value;
    public int Value
    {
        get
        {
            return _value; 
        }
        set
        {
            if (_value == value) { return; }

            _value = value;

            if (OnValueChanged != null)
            {
                OnValueChanged(_value);
            }
        }
    }
    public delegate void OnVariableChangeDelegate(int value);
    public event OnVariableChangeDelegate OnValueChanged;

    public void ResetSO()
    {
        _value = init;
    }
}