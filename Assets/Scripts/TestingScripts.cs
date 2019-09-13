using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
// UNT0009
public class TestingScripts : MonoBehaviour
{
    // USP0004
    // Should not quick-fix/suggest private field with SerailizeField as readonly
    [SerializeField]
    int health = 100;

    // UNT0001
    void Start()
    {
        
    }

    // USP0003
    // Should not show any diagnostics about unused/uncalled method even though there is no static call to this method.
    private void Awake()
    {
        Debug.Log(health);
    }

    void UNT0002()
    {
        Debug.Log(tag == "tag1");
    }

    void UNT0003()
    {
        var rb = GetComponent(typeof(Rigidbody)) as Rigidbody;
    }

    private void Update()
    {
        // UNT0004
        var test = Time.fixedDeltaTime;
    }

    private void FixedUpdate()
    {
        // UNT0005
        var test = Time.deltaTime;
    }

    // UNT0006
    private void OnCollisionEnter(Collider collision)
    {
        
    }

    public Transform a;
    public Transform b;

    public Transform NC()
    {
        // UNT0007
        return a ?? b;
    }

    public Transform NP()
    {
        // UNT0008
        return transform?.transform;
    }

    void UNT0010()
    {
        var test = new PlayerMovement();
    }

    void UNT0011()
    {
        var test = new ScriptableObject();
    }

    Transform USP0001()
    {
        // Should not show a suggestion to use null collescing
        return a != null ? a : b;
    }

    Transform USP0002()
    {
        // Should not show a suggestion to use null propagation
        if(transform != null)
            return transform.transform;

        return null;
    }
}
