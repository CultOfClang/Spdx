using System;
using Pidgin;
using Pidgin.Expression;
using static Pidgin.Parser;

namespace Spdx
{

    /// <summary>
    /// From https://github.com/benjamin-hodgson/Pidgin/blob/master/Pidgin.Examples/Expression/
    /// </summary>
    public static class ParserUtils
    {
        public static Parser<char, Func<IExpr, IExpr, IExpr>> Binary<T>(Parser<char, T> op)
    => op.Select<Func<IExpr, IExpr, IExpr>>(type => (l, r) => new BinaryOp<T>(type, l, r));
        public static Parser<char, Func<IExpr, IExpr>> Unary(Parser<char, UnaryOperatorType> op)
            => op.Select<Func<IExpr, IExpr>>(type => o => new UnaryOp(type, o));

        public static Parser<char, T> Tok<T>(Parser<char, T> token)
    => Try(token).Before(SkipWhitespaces);
        public static Parser<char, string> Tok(string token)
            => Tok(String(token));

        public static Parser<char, T> Parenthesised<T>(Parser<char, T> parser)
            => parser.Between(Tok("("), Tok(")"));
        public interface IExpr : IEquatable<IExpr>
        {
        }
        public class UnaryOp : IExpr
        {
            public UnaryOperatorType Type { get; }
            public IExpr Expr { get; }

            public UnaryOp(UnaryOperatorType type, IExpr expr)
            {
                Type = type;
                Expr = expr;
            }

            public bool Equals(IExpr other)
                => other is UnaryOp u
                && this.Type == u.Type
                && this.Expr.Equals(u.Expr);
        }
        public class BinaryOp<BinaryOperatorType> : IExpr
        {
            public BinaryOperatorType Type { get; }
            public IExpr Left { get; }
            public IExpr Right { get; }

            public BinaryOp(BinaryOperatorType type, IExpr left, IExpr right)
            {
                Type = type;
                Left = left;
                Right = right;
            }

            public bool Equals(IExpr other)
                => other is BinaryOp<BinaryOperatorType> b
                && this.Type.Equals(b.Type)
                && this.Left.Equals(b.Left)
                && this.Right.Equals(b.Right);
        }
    }
}
