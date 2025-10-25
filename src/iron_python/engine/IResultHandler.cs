using System;

namespace MyChatDB.src.iron_python.util
{
    public interface IResultHandler
    {
        void HandleResult(ResultObject resultObject);
    }
}
