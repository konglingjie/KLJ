using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLibrary4.Query
{
    public class AliasExpression : SqlExpression
    {
        public SqlExpression Exp { get; protected set; }

        public new string Alias { get; protected set; }

        protected AliasExpression()
        {
        }

        public override ExpressionType NodeType
        {
            get { return ExpressionType.Alias; }
        }

        public override string OutputSqlString(CommonLibrary4.Database.SqlBuilder.ISqlBuilder builder, CommonLibrary4.Database.ParameterCollection output)
        {
            return string.Concat(Exp.OutputSqlString(builder, output), " AS ", Alias);
        }

        internal static AliasExpression Expression(SqlExpression expression, string alias)
        {
            if (expression == null)
                throw new ArgumentNullException("expression");
            if (string.IsNullOrEmpty(alias))
                throw new ArgumentNullException("alias");

            return new AliasExpression() { Exp = expression, Alias = alias };
        }
    }
}
