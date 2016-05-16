using MongoDB.Bson.Serialization.Attributes;

namespace Problem1
{
    /// <summary>
    /// Note class for dictionary
    /// </summary>
    [BsonIgnoreExtraElements]
    public class Note
    {
        /// <summary>
        /// Man's number
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Man's name
        /// </summary>
        public string Name { get; set; }
    }
}
