using Core.Entities;
using Core.Enums;

namespace Core.Builders
{

    public class UserStatusBuilder
    {
        public User UserData { get; set; }

        public UserStatusBuilder(User updateData)
        {
            if(updateData == null) throw new ArgumentNullException(nameof(updateData));
            UserData = updateData;
        }

        public User Reactivate()
        {
            UserData.UserStatus = UserStatus.Active;
            return UserData;
        }

        public User Desactivate()
        {
            UserData.UserStatus = UserStatus.Inactive;
            return UserData;
        }

        public User Pause()
        {
            UserData.UserStatus = UserStatus.Paused;
            return UserData;
        }

        public User Delete()
        {
            UserData.UserStatus = UserStatus.Deleted;
            return UserData;
        }
    }
}
