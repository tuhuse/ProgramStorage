using System;

public interface IStatusUI
{
    event Action<int, int> OnHpChanged; // (����HP, �ő�HP)
}
