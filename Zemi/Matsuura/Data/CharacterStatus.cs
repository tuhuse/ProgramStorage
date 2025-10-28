using UnityEngine;
using System.Collections;
public class CharacterStatus
{
    private int _characterMaxHealth=default;
    private int _characterHealth=default;
    private float _characterDonwTime=default;
    private const float FLASH_TIME = 0.5f;
    private bool _isCharacterDown=false;
    public bool IsCharacterDown()
    {
        return _isCharacterDown;
    }
    public void SetStatus(CharacterData data)
    {
        _characterDonwTime = data.CharacterDownTime;
        _characterMaxHealth = data.CharacterHealth;
        _characterHealth = _characterMaxHealth;
        
    }

    public void TakeDamage()
    {
        if (_isCharacterDown)
        {
            return;
        }
        _characterHealth--;
        CheckHealth();
    }

    private void CheckHealth()
    {
        if (_characterHealth <= 0)
        {
            _characterHealth = 0;     
            _isCharacterDown = true;         
        }
    }

    public IEnumerator DownCharacterCoroutine()
    {
        
        yield return new WaitForSeconds(_characterDonwTime);        
        _characterHealth = _characterMaxHealth;
        _isCharacterDown = false;
    }
    public IEnumerator FlashFrog(GameObject target)
    {
        SpriteRenderer targetSprite = target.GetComponent<SpriteRenderer>();
        targetSprite.enabled = false;
        yield return new WaitForSeconds(FLASH_TIME);
        targetSprite.enabled = true;
        yield return new WaitForSeconds(FLASH_TIME);
        targetSprite.enabled = false;
        yield return new WaitForSeconds(FLASH_TIME);
        targetSprite.enabled = true;
        yield return new WaitForSeconds(FLASH_TIME);
        targetSprite.enabled = false;
        yield return new WaitForSeconds(FLASH_TIME);
        targetSprite.enabled = true;
    }
   
}
