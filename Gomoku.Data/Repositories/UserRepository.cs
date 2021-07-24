using Gomoku.Data.Entities;
using Gomoku.Data.Interfaces;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tofi.Framework.Data.Configuration;
using Tofi.Framework.Data.Repositories;
using Tofi.Framework.Data.Translation;
using Tofi.Framework.Parameters;
using Tofi.Framework.Responses;
using Tofi.Framework.Sorting;

namespace Gomoku.Data.Repositories
{
    public class UserRepository : BaseEntityRepository<UserEntity>, IUserRepository
    {
        public UserRepository(
            IDatabaseConfiguration databaseConfiguration,
            IOrmLiteDialectProvider ormLiteDialetProvider,
            IDatabaseErrorTranslator databaseErrorTranslator) : base(databaseConfiguration, ormLiteDialetProvider, databaseErrorTranslator)
        {

        }
       
    }
}
