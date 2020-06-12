using System;


namespace LittleFarmGame
{
    internal interface IShouldSave
    {
        event Action ShouldSave;
    }
}