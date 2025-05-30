using TinySerializer.Core.DataReaderWriters;
using TinySerializer.Core.Misc;

namespace TinySerializer.Core.Serializers {
    public sealed class SingleSerializer : Serializer<float> {
        public override float ReadValue(IDataReader reader) {
            string name;
            EntryType entry = reader.PeekEntry(out name);
            
            if (entry == EntryType.FloatingPoint || entry == EntryType.Integer) {
                float value;
                
                if (reader.ReadSingle(out value) == false) {
                    reader.Context.Config.DebugContext.LogWarning("Failed to read entry '" + name + "' of type " + entry.ToString());
                }
                
                return value;
            } else {
                reader.Context.Config.DebugContext.LogWarning("Expected entry of type " + EntryType.FloatingPoint.ToString() + " or " + EntryType.Integer.ToString()
                                                              + ", but got entry '" + name + "' of type " + entry.ToString());
                
                reader.SkipEntry();
                return default(float);
            }
        }
        
        public override void WriteValue(string name, float value, IDataWriter writer) {
            FireOnSerializedType();
            writer.WriteSingle(name, value);
        }
    }
}