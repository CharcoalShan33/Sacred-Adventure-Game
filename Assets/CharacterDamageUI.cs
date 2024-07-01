using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterDamageUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI damageText;
    [SerializeField] float lifetime = 1f, moveSpeed = 1f; //textVibrations = .04f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, lifetime);
        transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0f);
        
    }

    public void SetDamage(int damage)
    {
        damageText.text = damage.ToString();
    }
}
