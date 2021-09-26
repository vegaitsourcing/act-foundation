using ACTFoundation.Core.Models.Database;
using Umbraco.Core.Migrations;

namespace ACTFoundation.Core.Database
{
    public class NewsletterSubscriptionMigrationPlan : MigrationPlan
    {
        public NewsletterSubscriptionMigrationPlan(string name) : base(name)
        {
            From(string.Empty).To<MigrationCreateTables>("newsletter-migration");
        }
    }

    public class MigrationCreateTables : MigrationBase
    {
        public MigrationCreateTables(IMigrationContext context) : base(context)
        {
        }

        public override void Migrate()
        {
            if (!TableExists("NewsletterSubscription"))
            {
                Create.Table<NewsletterSubscriptionDatabaseModel>().Do();
            }
        }
    }
}