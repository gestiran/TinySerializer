using System;
using TinySerializer.Core.DataReaderWriters;

namespace TinySerializer.Core.Formatters {
    public interface IFormatter {
        Type SerializedType { get; }
        
        void Serialize(object value, IDataWriter writer);
        
        object Deserialize(IDataReader reader);
    }
    
    public interface IFormatter<T> : IFormatter {
        void Serialize(T value, IDataWriter writer);
        
        new T Deserialize(IDataReader reader);
    }
}