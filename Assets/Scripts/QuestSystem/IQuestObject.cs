using System;

namespace QuestSystem
{
    public interface IQuestObject
    {
        Action AttachEvent { get; set; }
    }
}
