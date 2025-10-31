using System;

namespace MyChatDB.iron_python.engine
{
    public interface IResultHandler
    {
        void HandleResult(ResultObject resultObject);
        void PrintLn(string text);
    }
}
