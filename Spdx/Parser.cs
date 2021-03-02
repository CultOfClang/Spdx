using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using Pidgin;
using Pidgin.Expression;
using static Pidgin.Parser;
using static Pidgin.Parser<char>;
using static Spdx.ParserUtils;
namespace Spdx
{

    public class Parser
    {
        //public Parser<char, string> Parser;
        public Parser()
        {
            var and = Binary(Tok("AND").ThenReturn(Conjunction.And));
            var with = Binary(Tok("WITH").ThenReturn(Conjunction.With));
            var or = Binary(Tok("OR").ThenReturn(Conjunction.With));


            var idstring = Tok(OneOf(LetterOrDigit, Char('-'), Char('.')).AtLeastOnceString());
            
            
            var licenseId = idstring;
            var licenseExceptionId = idstring;
            var documentRef = String("DocumentRef-").ThenReturn(idstring);

            var licenseRef = documentRef.Then(Char(':')).Optional().Then(String("LicenseRef-").ThenReturn(idstring)).Select(x => "helpme");
            var simpleExpression = OneOf(
                licenseId,
                licenseId.Then(String("+")),
                licenseRef
                );

        }
    }


    public static class ExprParser
    {




        private static readonly Parser<char, Func<IExpr, IExpr, IExpr>> Add
            = Binary(Tok("+").ThenReturn(BinaryOperatorType.Add));
        private static readonly Parser<char, Func<IExpr, IExpr, IExpr>> Mul
            = Binary(Tok("*").ThenReturn(BinaryOperatorType.Mul));
        private static readonly Parser<char, Func<IExpr, IExpr>> Neg
            = Unary(Tok("-").ThenReturn(UnaryOperatorType.Neg));
        private static readonly Parser<char, Func<IExpr, IExpr>> Complement
            = Unary(Tok("~").ThenReturn(UnaryOperatorType.Complement));

        private static readonly Parser<char, IExpr> Identifier
            = Tok(Letter.Then(LetterOrDigit.ManyString(), (h, t) => h + t))
                .Select<IExpr>(name => new Identifier(name))
                .Labelled("identifier");
        private static readonly Parser<char, IExpr> Literal
            = Tok(Num)
                .Select<IExpr>(value => new Literal(value))
                .Labelled("integer literal");

        private static readonly Parser<char, IExpr> Expr = ExpressionParser.Build<char, IExpr>(
            expr => (
                OneOf(
                    Identifier,
                    Literal,
                    Parenthesised(expr).Labelled("parenthesised expression")
                ),
                new[]
                {
                    Operator.Prefix(Neg).And(Operator.Prefix(Complement)),
                    Operator.InfixL(Mul),
                    Operator.InfixL(Add)
                }
            )
        ).Labelled("expression");

        public static IExpr ParseOrThrow(string input)
            => Expr.ParseOrThrow(input);
    }
}
