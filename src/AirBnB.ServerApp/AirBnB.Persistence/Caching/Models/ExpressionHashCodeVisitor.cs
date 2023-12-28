using System.Linq.Expressions;

namespace AirBnB.Persistence.Caching.Models;

public class ExpressionHashCodeVisitor : ExpressionVisitor
{
    public int HashSum { get; private set; } = 17;

    // protected override Expression VisitBinary(BinaryExpression node) => Combine(node);
    //
    // protected override Expression VisitConditional(ConditionalExpression node) => Combine(node);
    //
    // protected override Expression VisitBlock(BlockExpression node) => Combine(node);
    //
    // protected override Expression VisitLambda<T>(Expression<T> node) => Combine(node);
    //
    // protected override Expression VisitMember(MemberExpression node) => Combine(node);
    //
    // protected override Expression VisitParameter(ParameterExpression node) => Combine(node);
    //
    // protected override Expression VisitUnary(UnaryExpression node) => Combine(node);
    //
    // protected override Expression VisitMemberInit(MemberInitExpression node) => Combine(node);
    //
    // protected override Expression VisitTypeBinary(TypeBinaryExpression node) => Combine(node);

    private void Combine(MethodCallExpression methodCallExpression)
    {
        HandlePaginationCall(methodCallExpression);
        HandleFilterCall(methodCallExpression);
    }

    private void HandlePaginationCall(MethodCallExpression methodCallExpression)
    {
        if (methodCallExpression.Method.Name is nameof(Queryable.Skip) or nameof(Queryable.Take))
        {
            HashSum = HashSum * 23 + HashCode.Combine(
                methodCallExpression.NodeType,
                methodCallExpression.Method.Name,
                (methodCallExpression.Arguments[1] as ConstantExpression)!.Value
            );
        }
    }

    private void HandleFilterCall(MethodCallExpression methodCallExpression)
    {
        if (methodCallExpression.Method.Name is nameof(Queryable.Where))
        {
            // TODO : Implement
        }
    }

    protected override Expression VisitMethodCall(MethodCallExpression node)
    {
        Combine(node);
        foreach (var expression in node.Arguments) Visit(expression);

        return node;
    }
}