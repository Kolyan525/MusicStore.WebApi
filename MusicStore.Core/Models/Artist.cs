using FluentValidation;
using MongoDB.Bson.Serialization.Attributes;

namespace MusicStore.Core
{
    public class Artist
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }
        public string Genre { get; set; }
        public int Albums { get; set; }
    }

    public class ArtistValidator : AbstractValidator<Artist>
    {
        public ArtistValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).Length(2, 30);
            RuleFor(x => x.Genre).Length(2, 20);
            RuleFor(x => x.Albums).InclusiveBetween(1, 30);
        }
    }
}
