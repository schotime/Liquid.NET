﻿using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Liquid.NET.Tests
{
    [TestFixture]
    public class CachingLiquidASTGeneratorTests
    {
        [Test]
        public void It_Should_Cache_A_Template()
        {
            // Arrange
            String tmpl = "<html>{{Test}}</html>";
            MockGenerator mockGenerator = new MockGenerator();
            var cachingGenerator = new CachingLiquidASTGenerator(mockGenerator);
            
            // Act
            var result1= cachingGenerator.Generate(tmpl);
            var result2 = cachingGenerator.Generate(tmpl);

            // Assert
            Assert.That(result1, Is.Not.Null);
            Assert.That(result2, Is.Not.Null);
            Assert.That(mockGenerator.Calls, Is.EqualTo(1));
        }

        [Test]
        public void It_Should_Not_Cache_Dissimilar_Templates()
        {
            // Arrange
            String tmpl = "test";
            MockGenerator mockGenerator = new MockGenerator();
            var cachingGenerator = new CachingLiquidASTGenerator(mockGenerator);

            // Act
            var result1 = cachingGenerator.Generate(tmpl);
            var result2 = cachingGenerator.Generate(tmpl + "2");

            // Assert
            Assert.That(result1, Is.Not.Null);
            Assert.That(result2, Is.Not.Null);
            Assert.That(mockGenerator.Calls, Is.EqualTo(2));
        }

        [Test]
        public void It_Should_Not_Cache_Erroring_Templates()
        {
            // Arrange
            String tmpl = "Result: {% weofijwef";
            var mockGenerator = new MockGeneratorWithError(new LiquidError{Message = "Bad Things Happened!"});
            var cachingGenerator = new CachingLiquidASTGenerator(mockGenerator);

            // Act
            var result1 = cachingGenerator.Generate(tmpl, err => { });
            var result2 = cachingGenerator.Generate(tmpl, err => { });

            // Assert
            Assert.That(result1, Is.Not.Null);
            Assert.That(result2, Is.Not.Null);
            Assert.That(mockGenerator.Calls, Is.EqualTo(2));
        }


        [Test]
        public void It_Should_Cache_A_Template_Across_Objects()
        {
            // Arrange
            String tmpl = "<html>{{Test 2}}</html>";
            MockGenerator mockGenerator = new MockGenerator();
            var cachingGenerator = new CachingLiquidASTGenerator(mockGenerator);
            var cachingGenerator2 = new CachingLiquidASTGenerator(mockGenerator);

            // Act
            cachingGenerator.Generate(tmpl);
            cachingGenerator2.Generate(tmpl);

            // Assert
            Assert.That(mockGenerator.Calls, Is.EqualTo(1));
        }


    }



    public class MockGenerator : ILiquidASTGenerator
    {
        public int Calls { get; private set; }
        public LiquidAST Generate(string template, Action<LiquidError> onParserError)
        {
            Calls ++;
            return new LiquidAST();
        }

        public LiquidASTGenerationResult Generate(string template)
        {
            throw new NotImplementedException();
        }
    }

    public class MockGeneratorWithError : ILiquidASTGenerator
    {
        private readonly LiquidError _err;

        public MockGeneratorWithError(LiquidError err)
        {
            _err = err;
        }

        public int Calls { get; private set; }

        public LiquidASTGenerationResult Generate(string template)
        {
            Calls++;
            return LiquidASTGenerationResult.Create(new LiquidAST(), new List<LiquidError> {_err});

        }

        public LiquidAST Generate(string template, Action<LiquidError> onParserError)
        {
            Calls++;
            if (onParserError != null)
            {
                onParserError(_err);
            }
            
            return new LiquidAST();
        }

    }

}
