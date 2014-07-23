using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLibrary4.Query
{
    public class VariableNameExpression : SqlExpression
    {
        public string Name { get; protected set; }

        protected VariableNameExpression(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
            this.Name = name;
        }

        public override ExpressionType NodeType
        {
            get { return ExpressionType.VariableName; }
        }

        public override string OutputSqlString(CommonLibrary4.Database.SqlBuilder.ISqlBuilder builder, CommonLibrary4.Database.ParameterCollection output)
        {
            return builder.BuildParameterName(Name);
        }

        internal static VariableNameExpression Expression(string name)
        {
            return new VariableNameExpression(name);
        }
    }
}
