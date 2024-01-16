using LinqToDB;
using LinqToDB.Data;
using LinqToDB.DataProvider.MySql;

namespace Nop.Data.DataProviders.LinqToDb;


/// <summary>
/// Represents a data provider for MySql
/// </summary>
public partial class LinqToDbMySqlDataProvider : MySqlDataProvider
{
    #region Ctor

    public LinqToDbMySqlDataProvider() : base(ProviderName.MySqlConnector) { }

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
