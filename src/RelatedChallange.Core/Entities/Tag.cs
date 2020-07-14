using RelatedChallange.Core.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace RelatedChallange.Core.Entities
{
    public class Tag : Entity
    {
        [Required, StringLength(80)]
        public string Name { get; set; }

        public static Tag Create(int tagId, string name)
        {
            var tag = new Tag
            {
                Id = tagId,
                Name = name,
            };
            return tag;
        }
    }
}
