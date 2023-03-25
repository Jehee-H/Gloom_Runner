using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterInfo", menuName = "Character Info")]
public class charInfo : ScriptableObject
{
    public new string name;
    public string description;

    public float speedValue;
    public float jumpValue;
    public float dashingVelocity;
    public float dashingTime;
    public float yDashingVelocity;
    public float optimizeYVelocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
