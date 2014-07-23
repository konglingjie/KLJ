using CommonLibrary4.Database.SqlBuilder;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLibrary4.Query
{
    public class ConstantExpression : SqlExpression
    {
        public object Value { get; private set; }

        protected ConstantExpression(object value)
        {
            this.Value = value;
        }

        public override ExpressionType NodeType
        {
            get { return ExpressionType.Constant; }
        }

        public override string OutputSqlString(ISqlBuilder builder, CommonLibrary4.Database.ParameterCollection output)
        {
            return output.Append("p", Value, true).ParameterName;
        }

        internal static ConstantExpression Expression(object value)
        {
            return new ConstantExpression(value);
        }
    }
}
