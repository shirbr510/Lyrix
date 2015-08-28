using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Lyrix.Attributes;
using Lyrix.Data;
using Lyrix.Data.Abstract;
using Lyrix.Parsers.Abstract;

namespace Lyrix.Parsers
{
    public class TagsParser : ITagsParser
    {
        private readonly IDictionary<string, string> _prefixToPropertyDictionary;

        public TagsParser()
            : this(typeof(ILyrixTags))
        {

        }

        private TagsParser(Type tagsType)
        {
            var lyrixTagsType = typeof(ILyrixTags);
            if (tagsType != lyrixTagsType && !tagsType.IsSubclassOf(lyrixTagsType))
            {
                throw new ArgumentException(string.Format("Type should derive from {0}", lyrixTagsType));
            }
            var properties = tagsType.GetProperties();
            var dict = new Dictionary<string, string>();
            foreach (var propertyInfo in properties)
            {
                var prefix = propertyInfo.GetCustomAttributes(typeof(PrefixAttribute), false)
                    .Cast<PrefixAttribute>()
                    .First()
                    .Value;
                var value = propertyInfo.Name;
                dict.Add(prefix, value);
            }
            _prefixToPropertyDictionary = dict;
        }

        public string Format { get { return @"\[(?<Prefix>[a-z]*):(?<Value>.*)\]"; } }


        public ILyrixTags ParseTags(string tags)
        {
            var tagsObject = new LyrixTags();
            var matchCollection = Regex.Matches(tags, Format);
            if (matchCollection.Count == 0)
            {
                return null;
            }
            foreach (Match match in matchCollection)
            {
                var prefix = match.Groups["Prefix"].Value;
                var value = match.Groups["Value"].Value;
                if (_prefixToPropertyDictionary.ContainsKey(prefix))
                {
                    var prop = typeof(ILyrixTags).GetProperty(_prefixToPropertyDictionary[prefix]);
                    if (prop != null)
                    {
                        prop.SetValue(tagsObject, Convert.ChangeType(value, prop.PropertyType));
                    }
                }
            }
            return tagsObject;
        }
    }
}
