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
            if (!string.IsNullOrEmpty(name))
            {
                UserData.Name = name;
            }
            return this;
        }

        public UpdateBuilder SetLastName(string lastname)
        {
            if (!string.IsNullOrEmpty(lastname))
            {
                UserData.LastName = lastname;
            }
            return this;
        }

        public UpdateBuilder SetEmail(string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                UserData.Email = email;
            }
            return this;
        }

        public User Build()
        {
            // make foreign validations => like: initalDate > endDate
            UserData.ModifiedDate = DateTime.UtcNow;
            return UserData;
        }
    }
}
