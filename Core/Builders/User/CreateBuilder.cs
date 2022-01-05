using Ardalis.GuardClauses;

using Core.Entities;

namespace Core.Builders
{
    public class CreateBuilder
    {
        public User UserData { get; set; }

        public CreateBuilder()
        {
            UserData = new User();
        }

        public CreateBuilder SetName(string name)
        {
            Guard.Against.NullOrWhiteSpace(name, "{0} cant be null or white space", nameof(name));
            UserData.Name = name;
            return this;
        }
        
        public CreateBuilder SetLastName(string lastname)
        {
            Guard.Against.NullOrWhiteSpace(lastname, "{0} cant be null or white space", nameof(lastname));
            UserData.LastName = lastname;
            return this;
        }

        public CreateBuilder SetEmail(string email)
        {
            Guard.Against.NullOrWhiteSpace(email, "{0} cant be null or white space", nameof(email));
            UserData.Email = email;
            return this;
        }

        public User Build()
        {
            // make foreign validations => initalDate > endDate for example
            UserData.Id = Guid.NewGuid();
            return UserData;
        }
    }
}
