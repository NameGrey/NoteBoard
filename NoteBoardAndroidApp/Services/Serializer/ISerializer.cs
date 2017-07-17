using System;
using System.Collections.Generic;

namespace NoteBoardAndroidApp.Services.Serializer
{
    public interface ISerializer
    {
        T Deserialize<T>(string json);
        string Serialize<T>(T entity);
    }
}