using System.Data.Common;
using LinqToDB;
using LinqToDB.Common;
using LinqToDB.Data;
using LinqToDB.DataProvider.PostgreSQL;
using Nop.Data.DataProviders.LinqToDb;

namespace Nop.Data.DataProviders.LinqToDB;

/// <summary>
/// Represents a data provider for PostgreSQL
/// </summary>
public partial class LinqToDBPostgreSQLDataProvider : PostgreSQLDataProvider
{
    #region Ctor

    public LinqToDBPostgreSQLDataProvider() : base(ProviderName.PostgreSQL, PostgreSQLVersion.v95) { }

    #endregion

    #region Methods
    
    public override void SetParameter(DataConnection dataConnection, DbParameter parameter, string name, DbDataType dataType, object value)
    {
        if (value is string && dataType.DataType == DataType.NVarChar)
        {
            dataType = dataType.WithDbType("citext");
        }

        base.SetParameter(dataConnection, parameter, name, dataType, value);
    }

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