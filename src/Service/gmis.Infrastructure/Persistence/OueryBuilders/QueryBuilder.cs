using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gmis.Infrastructure.Persistence.OueryBuilders
{
    public enum Logic
    {
        AND = 0,
        OR
    }

    public enum JoinOptions
    {
        InnerJoin = 0,
        LeftJoin,
        RightJoin,
        CrossJoin
    }

    public class QueryCondition
    {
        Logic _operation;
        string _condition;

        public string Condition
        {
            get { return _condition; }
            set { _condition = value; }
        }

        public Logic Operation
        {
            get { return _operation; }
            set { _operation = value; }
        }
    }
    public class QueryJoinClause
    {
        JoinOptions _joinMethod = JoinOptions.InnerJoin;
        string _subject;
        string _criteria;

        public JoinOptions JoinMethod
        {
            get { return _joinMethod; }
            set { _joinMethod = value; }
        }

        public string Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }

        public string Criteria
        {
            get { return _criteria; }
            set { _criteria = value; }
        }
    }
    public class QueryBuilder
    {
        string[] _columns;
        string _table;
        List<QueryJoinClause> _joinCluses = new List<QueryJoinClause>();
        List<QueryCondition> _conditions = new List<QueryCondition>();
        string[] _groupByColumns;
        string[] _orderByColumns;
        string _orderByDirection;

        public string[] Columns
        {
            get { return _columns; }
            set { _columns = value; }
        }

        public string Table
        {
            get { return _table; }
            set { _table = value; }
        }

        public List<QueryJoinClause> JoinCluses
        {
            get { return _joinCluses; }
            set { _joinCluses = value; }
        }

        public List<QueryCondition> Conditions
        {
            get { return _conditions; }
            set { _conditions = value; }
        }

        public string[] GroupByColumns
        {
            get { return _groupByColumns; }
            set { _groupByColumns = value; }
        }

        public string[] OrderByColumns
        {
            get { return _orderByColumns; }
            set { _orderByColumns = value; }
        }

        public string OrderByDirection
        {
            get { return _orderByDirection; }
            set { _orderByDirection = value; }
        }

        public string GetConcatenatedColumns()
        {
            return string.Join(",", Columns);
        }

        public string BuildQuery()
        {
            if (Columns == null || Columns.Length == 0)
                throw new ArgumentException("Column can not be null or empty.");

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT ");
            sql.Append(string.Join(",", Columns));
            sql.Append(" FROM ");
            sql.Append(Table);

            if (JoinCluses != null && JoinCluses.Count > 0)
            {
                foreach (var i in JoinCluses)
                {
                    sql.AppendLine();
                    switch (i.JoinMethod)
                    {
                        case JoinOptions.InnerJoin:
                            sql.Append("INNER JOIN"); break;
                        case JoinOptions.LeftJoin:
                            sql.Append("LEFT JOIN"); break;
                        case JoinOptions.RightJoin:
                            sql.Append("RIGHT JOIN"); break;
                        case JoinOptions.CrossJoin:
                            sql.Append("CROSS JOIN"); break;
                        default:
                            throw new ArgumentException("Unsupported JoinOptions");
                    }

                        sql.Append(" ");
                        sql.Append(i.Subject);
                    if (i.JoinMethod != JoinOptions.CrossJoin)
                    {
                        sql.Append(" ON ");
                        sql.Append(i.Criteria);
                    }
                }
            }
            if (Conditions != null && Conditions.Count > 0)
            {
                sql.AppendLine(" WHERE ");
                for (int i = 0; i < Conditions.Count; i++)
                {
                    if (i > 0)
                    {
                        sql.Append(Conditions[i].Operation.ToString());
                        sql.Append(" ");
                        sql.Append(Conditions[i].Condition);
                        sql.Append(" ");
                    }
                    else
                    {
                        sql.Append(Conditions[i].Condition);
                        sql.Append(" ");
                    }
                }
            }
            if (GroupByColumns != null && GroupByColumns.Length > 0)
            {
                sql.AppendLine(" GROUP BY ");
                sql.Append(string.Join(",", GroupByColumns));
            }
            if (OrderByColumns != null && OrderByColumns.Length > 0)
            {
                sql.AppendLine(" ORDER BY ");
                sql.Append(string.Join(",", OrderByColumns));
                sql.Append(" ");
                sql.Append(OrderByDirection);
            }

            return sql.ToString();
        }

        public string BuildCountQuery()
        {
            if (Columns == null || Columns.Length == 0)
                throw new ArgumentException("Column can not be null or empty.");

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT ");
            sql.Append("COUNT(*)");
            sql.Append(" FROM ");
            sql.Append(Table);

            if (JoinCluses != null && JoinCluses.Count > 0)
            {
                foreach (var i in JoinCluses)
                {
                    sql.AppendLine();
                    switch (i.JoinMethod)
                    {
                        case JoinOptions.InnerJoin:
                            sql.Append("INNER JOIN"); break;
                        case JoinOptions.LeftJoin:
                            sql.Append("LEFT JOIN"); break;
                        case JoinOptions.RightJoin:
                            sql.Append("RIGHT JOIN"); break;
                        case JoinOptions.CrossJoin:
                            sql.Append("CROSS JOIN"); break;
                        default:
                            throw new ArgumentException("Unsupported JoinOptions");
                    }

                    sql.Append(" ");
                    sql.Append(i.Subject);
                    sql.Append(" ON ");
                    sql.Append(i.Criteria);
                }
            }
            if (Conditions != null && Conditions.Count > 0)
            {
                sql.AppendLine(" WHERE ");
                for (int i = 0; i < Conditions.Count; i++)
                {
                    if (i > 0)
                    {
                        sql.Append(" ");
                        sql.Append(Conditions[i].Operation.ToString());
                        sql.Append(" ");
                        sql.Append(Conditions[i].Condition);
                        sql.Append(" ");
                    }
                    else
                    {
                        sql.Append(Conditions[i].Condition);
                        sql.Append(" ");
                    }
                }
            }
            return sql.ToString();
        }
    }
}
