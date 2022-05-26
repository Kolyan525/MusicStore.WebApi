using FluentValidation;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MusicStore.Core
{
    public class Song
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        public string Title { get; set; }

        public string Artist { get; set; }

        public string Album { get; set; }

        public string Category { get; set; }
}

    public class SongValidator : AbstractValidator<Song>
    {
        public SongValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Title).Length(2, 30);
            RuleFor(x => x.Artist).Length(2, 20);
            RuleFor(x => x.Album).Length(1, 30);
            RuleFor(x => x.Category).Length(1, 20);
        }
    }
}
