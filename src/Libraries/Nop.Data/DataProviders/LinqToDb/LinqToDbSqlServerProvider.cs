using LinqToDB;
using LinqToDB.Data;
using LinqToDB.DataProvider.SqlServer;

namespace Nop.Data.DataProviders.LinqToDb;

/// <summary>
/// Represents a data provider for SQL Server
/// </summary>
public partial class LinqToDbSqlServerProvider : SqlServerDataProvider
{
    #region Ctor

    public LinqToDbSqlServerProvider() : base(ProviderName.SqlServer2012, SqlServerVersion.v2012, SqlServerProvider.MicrosoftDataSqlClient) { }

    #endregion

    #region Methods

    /// <summary>
    /// Returns scoped context object to wrap calls of Execute* methods.
    /// Using this, provider could e.g. change thread culture during Execute* calls.
    /// Following calls wrapped right now:
    /// DataConnection.ExecuteNonQuery
    /// DataConnection.ExecuteReader.
    /// </summary>
    /// <param name="dataConnection">Data connection instance used with scope.</param>
    /// <returns>Returns disposable scope object. Can be <c>null</c>.</returns>
    public override IExecutionScope ExecuteScope(DataConnection dataConnection)
    {
        return new InvariantCultureRegion(null);
    }

    #endregion
}
