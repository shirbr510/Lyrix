using System;

namespace Lyrix.Attributes
{
    /// <summary>
    /// Specifies a prefix for a TagsObject.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    class PrefixAttribute : Attribute
    {
        public PrefixAttribute(string value)
        {
            Value = value;
        }

        public string Value { get; set; }
    }
}
