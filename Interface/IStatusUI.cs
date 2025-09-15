using System;

public interface IStatusUI
{
    event Action<int, int> OnHpChanged; // (åªç›HP, ç≈ëÂHP)
}
