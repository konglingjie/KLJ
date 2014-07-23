using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLibrary4.Query
{
    public class DbNullExpression : ConstantExpression
    {
        public static readonly DbNullExpression Instance;

        static DbNullExpression()
        {
            Instance = new DbNullExpression();
        }

        private DbNullExpression()
            : base(null)
        {
        }

        public override ExpressionType NodeType
        {
            get { return ExpressionType.Null; }
        }

        public override string OutputSqlString(CommonLibrary4.Database.SqlBuilder.ISqlBuilder builder, CommonLibrary4.Database.ParameterCollection output)
        {
            return "NULL";
        }
    }
}
