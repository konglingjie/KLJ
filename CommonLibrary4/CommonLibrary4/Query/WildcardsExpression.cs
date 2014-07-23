using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLibrary4.Query
{
    public class WildcardsExpression : ConstantExpression
    {
        public static readonly WildcardsExpression Instance;

        static WildcardsExpression()
        {
            Instance = new WildcardsExpression();
        }

        private WildcardsExpression()
            : base("%")
        {
        }

        public override string OutputSqlString(CommonLibrary4.Database.SqlBuilder.ISqlBuilder builder, CommonLibrary4.Database.ParameterCollection output)
        {
            return "'%'";
        }
    }
}
