using FluentValidation;
using MongoDB.Bson.Serialization.Attributes;

namespace MusicStore.Core
{
    public class Genre
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }
    }

    public class GenreValidator : AbstractValidator<Genre>
    {
        public GenreValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).Length(1, 20);
        }
    }
}
