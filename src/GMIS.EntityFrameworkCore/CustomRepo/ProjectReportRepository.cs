using Abp.Data;
using Abp.EntityFrameworkCore;
using GMIS.Authorization.Users;
using GMIS.CustomRepos;
using GMIS.Entity;
using GMIS.EntityFrameworkCore;
using GMIS.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace GMIS.CustomRepo
{
    public class ProjectReportRepository : GMISRepositoryBase<Project, Guid>, IProjectReportRepository
    {
        private readonly IActiveTransactionProvider _transactionProvider;

        public ProjectReportRepository(IDbContextProvider<GMISDbContext> dbContextProvider, IActiveTransactionProvider transactionProvider)
            : base(dbContextProvider)
        {
            _transactionProvider = transactionProvider;
        }

        public async Task<List<UserProjectViewModel>> GetUsersInProjects()
        {
            EnsureConnectionOpen();

            using (var command = CreateCommand("GetUsersInProjects", CommandType.StoredProcedure))
            {
                using (var dataReader = await command.ExecuteReaderAsync())
                {
                    var result = new List<UserProjectViewModel>();

                    while (dataReader.Read())
                    {
                        UserProjectViewModel r = new UserProjectViewModel();
                        r.ProjectName = dataReader["Name"].ToString();
                        r.UserEmail = dataReader["UserName"].ToString();
                        try
                        {
                           r.ProjectId = Guid.Parse(dataReader["ProjectId"].ToString());
                        }catch(Exception)
                        {

                        }
                        result.Add(r);
                    }

                    return result;
                }
            }
        }

        public async Task<List<GraphData_Dto_ProcedureCall>> GetNoOfProjectCountGroupByProgramTypeAsync()
        {
            EnsureConnectionOpen();

            using (var command = CreateCommand("GetProjectCountGroupByProgramType", CommandType.StoredProcedure))
            {
                using (var dataReader = await command.ExecuteReaderAsync())
                {
                    var result = new List<GraphData_Dto_ProcedureCall>();

                    while (dataReader.Read())
                    {
                        GraphData_Dto_ProcedureCall r = new GraphData_Dto_ProcedureCall();
                        r.DisplayName = dataReader["ProgramName"].ToString();
                        try
                        {
                            decimal number;
                            var temp = dataReader["cnt"].ToString();
                            if (Decimal.TryParse(temp, out number))
                            {
                                r.Values = number;
                            }
                            else
                            {
                                r.Values = 0;
                            }

                        }
                        catch (Exception)
                        {
                            r.Values = 0;
                        }
                        result.Add(r);
                    }

                    return result;
                }
            }
        }

        public async Task<List<GraphData_Dto_ProcedureCall>> GetSumGCACountGroupByProgramTypeAsync()
        {
            EnsureConnectionOpen();

            using (var command = CreateCommand("GetSumGCAGroupByProgramType", CommandType.StoredProcedure))
            {
                using (var dataReader = await command.ExecuteReaderAsync())
                {
                    var result = new List<GraphData_Dto_ProcedureCall>();

                    while (dataReader.Read())
                    {
                        GraphData_Dto_ProcedureCall r = new GraphData_Dto_ProcedureCall();
                        r.DisplayName = dataReader["ProgramName"].ToString();
                        try
                        {
                            decimal number;
                            var temp = dataReader["cnt"].ToString();
                            if (Decimal.TryParse(temp, out number))
                            {
                                r.Values = number;
                            }
                            else
                            {
                                r.Values = 0;
                            }

                        }
                        catch (Exception)
                        {
                            r.Values = 0;
                        }
                        result.Add(r);
                    }

                    return result;
                }
            }
        }

        //TODO: Make async!
        //public async Task<List<string>> GetUserNames()
        //{
        //    EnsureConnectionOpen();

        //    using (var command = CreateCommand("GetUsernames", CommandType.StoredProcedure))
        //    {
        //        using (var dataReader = await command.ExecuteReaderAsync())
        //        {
        //            var result = new List<string>();

        //            while (dataReader.Read())
        //            {
        //                result.Add(dataReader["UserName"].ToString());
        //            }

        //            return result;
        //        }
        //    }
        //}


        //public async Task<List<string>> GetAdminUsernames()
        //{
        //    EnsureConnectionOpen();

        //    using (var command = CreateCommand("SELECT * FROM dbo.UserAdminView", CommandType.Text))
        //    {
        //        using (var dataReader = await command.ExecuteReaderAsync())
        //        {
        //            var result = new List<string>();

        //            while (dataReader.Read())
        //            {
        //                result.Add(dataReader["UserName"].ToString());
        //            }
        //            return result;
        //        }
        //    }
        //}

        //public async Task DeleteUser(EntityDto input)
        //{
        //    await Context.Database.ExecuteSqlCommandAsync(
        //        "EXEC DeleteUserById @id",
        //        default(CancellationToken),
        //        new SqlParameter("id", input.Id)
        //    );
        //}

        //public async Task UpdateEmail(UpdateEmailDto input)
        //{
        //    await Context.Database.ExecuteSqlCommandAsync(
        //        "EXEC UpdateEmailById @email, @id",
        //        default(CancellationToken),
        //        new SqlParameter("id", input.Id),
        //        new SqlParameter("email", input.EmailAddress)
        //    );
        //}

        //public async Task<GetUserByIdOutput> GetUserById(EntityDto input)
        //{
        //    EnsureConnectionOpen();
        //    using (var command = CreateCommand("SELECT dbo.GetUsernameById(@id)", CommandType.Text, new SqlParameter("@id", input.Id)))
        //    {
        //        var username = (await command.ExecuteScalarAsync()).ToString();
        //        return new GetUserByIdOutput() { Username = username };
        //    }

        //}

        private DbCommand CreateCommand(string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            var command = Context.Database.GetDbConnection().CreateCommand();

            command.CommandText = commandText;
            command.CommandType = commandType;
            command.Transaction = GetActiveTransaction();

            foreach (var parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }

            return command;
        }

        private void EnsureConnectionOpen()
        {
            var connection = Context.Database.GetDbConnection();

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
        }

        private DbTransaction GetActiveTransaction()
        {
            return (DbTransaction)_transactionProvider.GetActiveTransaction(new ActiveTransactionProviderArgs
            {
                {"ContextType", typeof(GMISDbContext) },
                {"MultiTenancySide", MultiTenancySide }
            });
        }

    }
}
