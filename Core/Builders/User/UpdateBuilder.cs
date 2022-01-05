using Ardalis.GuardClauses;

using Core.Entities;

namespace Core.Builders
{
    public class UpdateBuilder
    {

        public User UserData { get; set; }

        public UpdateBuilder(User updateData)
        {
            UserData = updateData;
        }

        public UpdateBuilder SetName(string name)
        {
            Guard.Against.NullOrWhiteSpace(name, "{0} cant be null or white space", nameof(name));
            UserData.Name = name;
            return this;
        }

        public UpdateBuilder SetLastName(string lastname)
        {
            Guard.Against.NullOrWhiteSpace(lastname, "{0} cant be null or white space", nameof(lastname));
            UserData.LastName = lastname;
            return this;
        }

        public UpdateBuilder SetEmail(string email)
        {
            Guard.Against.NullOrWhiteSpace(email, "{0} cant be null or white space", nameof(email));
            UserData.Email = email;
            return this;
        }

        public User Build()
        {
            // make foreign validations => initalDate > endDate for example
            return UserData;
        }
    }
}
