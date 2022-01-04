using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Get to User Generic Repository
        /// </summary>
        public IGenericRepository<User> UserGenRepository { get; }

        /// <summary>
        /// Get to DeviceToken Generic Repository
        /// </summary>
        public IGenericRepository<DeviceToken> DeviceTokenGenRepository { get; }

        /// <summary>
        /// Get to UserPhone Generic Repository
        /// </summary>
        public IGenericRepository<UserPhone> UserPhoneGenRepository { get; }

        /// <summary>
        /// Get to UserScore Generic Repository
        /// </summary>
        public IGenericRepository<UserScore> UserScoreGenRepository { get; }

        /// <summary>
        /// Save all changes tracking
        /// </summary>
        /// <returns></returns>
        Task<bool> Commit();
    }
}
