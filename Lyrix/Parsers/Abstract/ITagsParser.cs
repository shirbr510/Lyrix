using Lyrix.Data.Abstract;

namespace Lyrix.Parsers.Abstract
{
    public interface ITagsParser : IParser
    {
        ILyrixTags ParseTags(string tags);
    }
}
