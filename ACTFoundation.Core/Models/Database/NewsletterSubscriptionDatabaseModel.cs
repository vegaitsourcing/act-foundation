using NPoco;
using Umbraco.Core.Persistence.DatabaseAnnotations;

namespace ACTFoundation.Core.Models.Database
{
    [TableName("NewsletterSubscription")]
    [PrimaryKey("Id", AutoIncrement = true)]
    [ExplicitColumns]
    public class NewsletterSubscriptionDatabaseModel
    {
        [Column("id")]
        [PrimaryKeyColumn(AutoIncrement = true)]
        public int Id { get; set; }

        [Column("email")]
        public string Email { get; set; }
    }
}