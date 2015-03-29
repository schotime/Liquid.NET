﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Liquid.NET.Constants;
using Liquid.NET.Expressions;
using Liquid.NET.Symbols;
using Liquid.NET.Tags;
using Liquid.NET.Utils;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Liquid.NET.Tests
{
    [TestFixture]
    public class LiquidASTExpressionParsingTests
    {
        LiquidASTGenerator _generator;

        [SetUp]
        public void SetUp()
        {
            _generator = new LiquidASTGenerator();
        }

        [Test]
        public void It_Should_Parse_And_And_Or()
        {
            
            // Act
            var ast = _generator.Generate("Result : {% if true and false or true %} OK {% endif %}");


            // Assert
            var ifThenSymbolNode =
                LiquidASTGeneratorTests.FindNodesWithType(ast, typeof (IfThenElseBlockTag)).FirstOrDefault();
            Assert.That(ifThenSymbolNode, Is.Not.Null);
            // ReSharper disable once PossibleNullReferenceException
            var predicateTree =
                ((IfThenElseBlockTag)ifThenSymbolNode.Data).IfElseClauses[0].ObjectExpressionTree;
            foreach (var expr in ((IfThenElseBlockTag)ifThenSymbolNode.Data).IfElseClauses)
            {
                DebugIfExpressions(expr.ObjectExpressionTree);
            }
            Assert.That(predicateTree.Data.Expression, Is.TypeOf<OrExpression>());
            Assert.That(predicateTree[0].Data.Expression, Is.TypeOf<AndExpression>());
            Assert.That(predicateTree[1].Data.Expression, Is.TypeOf<BooleanValue>());
            Assert.That(predicateTree[0][0].Data.Expression, Is.TypeOf<BooleanValue>());
            Assert.That(predicateTree[0][1].Data.Expression, Is.TypeOf<BooleanValue>());
        }

        [Test]
        public void It_Should_Parse_If_Var_Equals_String()
        {

            // Act
            var ast = _generator.Generate("Result : {% if myvar == \"hello\" %} OK {% endif %}");

            // Assert
            var ifThenSymbolNode =
                LiquidASTGeneratorTests.FindNodesWithType(ast, typeof(IfThenElseBlockTag)).FirstOrDefault();
            Assert.That(ifThenSymbolNode, Is.Not.Null);
            // ReSharper disable once PossibleNullReferenceException
            var predicateTree = ((IfThenElseBlockTag)ifThenSymbolNode.Data).IfElseClauses[0].ObjectExpressionTree;

            Assert.That(predicateTree.Data.Expression, Is.TypeOf<EqualsExpression>());
            Assert.That(predicateTree[0].Data.Expression, Is.TypeOf<VariableReference>());
            Assert.That(predicateTree[1].Data.Expression, Is.TypeOf<StringValue>());
            //Assert.That(predicateTree[0].Data, Is.TypeOf<VariableReference>());
            //Assert.That(predicateTree[1].Data, Is.TypeOf<String>());
        }

        [Test]
        public void It_Should_Parse_ElsIf()
        {
           
            // Act
            var ast = _generator.Generate("Result : {% if true %} OK {% elsif false %} NO {% elsif true %} YES {% endif %}");

            // Assert
            var ifThenSymbolNode =
                LiquidASTGeneratorTests.FindNodesWithType(ast, typeof(IfThenElseBlockTag)).FirstOrDefault();

            Assert.That(ifThenSymbolNode, Is.Not.Null);
            // ReSharper disable once PossibleNullReferenceException
            var elsIfPredicateTrees = ((IfThenElseBlockTag) ifThenSymbolNode.Data).IfElseClauses.Select(x => x.ObjectExpressionTree).ToList();

            foreach (var expr in ((IfThenElseBlockTag) ifThenSymbolNode.Data).IfElseClauses)
            {
                DebugIfExpressions(expr.ObjectExpressionTree);
            }
            Assert.That(elsIfPredicateTrees.Count, Is.EqualTo(3));

            Assert.That(elsIfPredicateTrees[0].Data.Expression, Is.TypeOf<BooleanValue>());
            Assert.That(elsIfPredicateTrees[1].Data.Expression, Is.TypeOf<BooleanValue>());
        }

        private void DebugIfExpressions(TreeNode<ObjectExpression> ifExpression, int level = 0)
        {
  
            Console.WriteLine("-> " + new string(' ', level * 2) +  ifExpression.Data);
            foreach (var child in ifExpression.Children)
            {
                DebugIfExpressions(child, level + 1);
            }
            
        }

        [Test]
        public void It_Should_Parse_Else()
        {
            // Act
            var ast = _generator.Generate("Result : {% if true %} OK {% elsif false %} NO {% elsif true %} YES {% else %} ELSE {% endif %}");

            // Assert
            var ifThenSymbolNode =
                LiquidASTGeneratorTests.FindNodesWithType(ast, typeof(IfThenElseBlockTag)).FirstOrDefault();
            Assert.That(ifThenSymbolNode, Is.Not.Null);
            // ReSharper disable once PossibleNullReferenceException
            var elseSymbols = ((IfThenElseBlockTag) ifThenSymbolNode.Data).IfElseClauses;

            Console.WriteLine("-- AST --");
            Console.WriteLine(new ASTWalker().Walk(ast));

            Assert.That(elseSymbols.Count, Is.EqualTo(4)); // the else symbol is an elsif set to "true".

        }

        [Test]
        public void It_Should_Parse_Nested_If()
        {

            // Act
            var ast = _generator.Generate("Result : {% if true %} {% if false %} True and false {% endif %} {% endif %}");

            // Assert
            var parentIfThenElseSymbol = LiquidASTGeneratorTests.FindNodesWithType(ast, typeof(IfThenElseBlockTag)).FirstOrDefault();

            var childIfThenElse = ((IfThenElseBlockTag) parentIfThenElseSymbol.Data).IfElseClauses[0].LiquidBlock;
            Console.WriteLine(childIfThenElse);
            Assert.That(childIfThenElse, Is.Not.Null);

        }

        [Test]
        public void It_Should_Add_A_Variable_Reference()
        {
            // Act
            var ast = _generator.Generate("Result : {% if myvar  %} OK {% endif %}");

            // Assert
            var ifThenElseNode = LiquidASTGeneratorTests.FindNodesWithType(ast, typeof(IfThenElseBlockTag)).FirstOrDefault();
            Assert.That(ifThenElseNode, Is.Not.Null);
            // ReSharper disable once PossibleNullReferenceException
            var ifThenElseSymbol = ((IfThenElseBlockTag)ifThenElseNode.Data);

            // Assert
            Assert.That(ifThenElseSymbol.IfElseClauses[0].ObjectExpressionTree.Data.Expression, Is.TypeOf<VariableReference>());

        }

        [Test]
        public void It_Should_Add_An_Int_Indexed_Array_Reference_In_An_Object()
        {
            // Act
            var ast = _generator.Generate("Result : {{ myvar[0] }}");

            // Assert
            var objExpression = LiquidASTGeneratorTests.FindNodesWithType(ast, typeof(ObjectExpressionTree)).FirstOrDefault();
            Assert.That(objExpression, Is.Not.Null);
            Assert.That(objExpression.Data, Is.Not.Null);
            var objectExpression = ((ObjectExpressionTree)objExpression.Data);

            // Assert
            Assert.That(objectExpression.ExpressionTree.Data.Expression, Is.Not.Null);
            Assert.That(objectExpression.ExpressionTree.Data.Expression, Is.TypeOf<VariableReference>());
            Assert.That(objectExpression.ExpressionTree.Data.FilterSymbols[0].Name, Is.EqualTo("lookup"));
        }

        [Test]
        public void It_Should_Add_A_String_Indexed_Array_Reference_In_An_Object()
        {
            // Act
            var ast = _generator.Generate("Result : {{ myvar[\"test\"] }}");

            // Assert
            var objExpression = LiquidASTGeneratorTests.FindNodesWithType(ast, typeof(ObjectExpressionTree)).FirstOrDefault();
            Assert.That(objExpression, Is.Not.Null);
            Assert.That(objExpression.Data, Is.Not.Null);
            var objectExpression = ((ObjectExpressionTree)objExpression.Data);

            // Assert
            Assert.That(objectExpression.ExpressionTree.Data.Expression, Is.Not.Null);
            Assert.That(objectExpression.ExpressionTree.Data.Expression, Is.TypeOf<VariableReference>());
            Assert.That(objectExpression.ExpressionTree.Data.FilterSymbols[0].Args[0], Is.TypeOf<StringValue>());

        }

        [Test]
        public void It_Should_Add_A_Boolean_Reference()
        {
            // Act
            var ast = _generator.Generate("Result : {% if true %} OK {% endif %}");
            var ifThenElseNode = LiquidASTGeneratorTests.FindNodesWithType(ast, typeof(IfThenElseBlockTag)).FirstOrDefault();
            Assert.That(ifThenElseNode, Is.Not.Null);
            // ReSharper disable once PossibleNullReferenceException
            var ifThenElseSymbol = ((IfThenElseBlockTag)ifThenElseNode.Data);

            // Assert
            Assert.That(ifThenElseSymbol.IfElseClauses[0].ObjectExpressionTree.Data.Expression, Is.TypeOf<BooleanValue>());

        }

        [Test]
        public void It_Should_Add_A_String_Reference()
        {
            // Act
            var ast = _generator.Generate("Result : {% if \"hello\" %} OK {% endif %}");
            var ifThenElseNode = LiquidASTGeneratorTests.FindNodesWithType(ast, typeof(IfThenElseBlockTag)).FirstOrDefault();
            Assert.That(ifThenElseNode, Is.Not.Null);
            // ReSharper disable once PossibleNullReferenceException
            var ifThenElseSymbol = ((IfThenElseBlockTag)ifThenElseNode.Data);

            // Assert
            Assert.That(ifThenElseSymbol.IfElseClauses[0].ObjectExpressionTree.Data.Expression, Is.TypeOf<StringValue>());

        }

 


    }
}
