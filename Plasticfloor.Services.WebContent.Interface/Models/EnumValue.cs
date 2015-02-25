using System;
using System.Runtime.Serialization;

namespace Plasticfloor.Services.WebContent.Interface.Models
{
    [Serializable]
    [DataContract]
    public class EnumValue<TEnum> where TEnum : struct
    {
        [DataMember]
        private string _value;

        public EnumValue(TEnum value = default(TEnum))
        {
            _value = value.ToString();
        }

        [IgnoreDataMember]
        public TEnum Value
        {
            get
            {
                TEnum value;
                return Enum.TryParse(_value, out value) ? value : default(TEnum);
            }
            set { _value = value.ToString(); }
        }
    }
}