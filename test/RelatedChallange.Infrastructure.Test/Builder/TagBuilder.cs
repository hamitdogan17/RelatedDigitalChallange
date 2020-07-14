using RelatedChallange.Core.Entities;

namespace RelatedChallange.Infrastructure.Test.Builder
{
    public class TagBuilder
    {
        public int TestTagId => 5;
        public string TestTagName => "Test Tag Name";
        public TagBuilder()
        {
            TagWithDefaultValues();
        }
        public Tag TagWithDefaultValues()
        {
            return Tag.Create(TestTagId, TestTagName);
        }
    }
}
