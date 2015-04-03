﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Liquid.NET.Tests.Tags
{
    [TestFixture]
    public class IfThenElseBlockTagTests
    {
        [Test]
        public void It_Should_Render_If_True()
        {
            // Act
            var result = RenderingHelper.RenderTemplate("Result : {% if true %}OK{% endif %}");

            // Assert
            Assert.That(result, Is.EqualTo("Result : OK"));
        }

        [Test]
        public void It_Should_Render_If_False()
        {
            // Act
            var result = RenderingHelper.RenderTemplate("Result : {% if false %}OK{% endif %}");

            // Assert
            Assert.That(result, Is.EqualTo("Result : "));
        }

        [Test]
        public void It_Should_Render_Else()
        {
            // Act
            var result = RenderingHelper.RenderTemplate("Result : {% if false %}OK{% else %}Else{% endif %}");

            // Assert
            Assert.That(result, Is.EqualTo("Result : Else"));
        }

        [Test]
        public void It_Should_Render_Elsif()
        {
            // Act
            var result = RenderingHelper.RenderTemplate("Result : {% if false %}OK{% elsif true %}Else If{% else %}Else{% endif %}");

            // Assert
            Assert.That(result, Is.EqualTo("Result : Else If"));
        }

        [Test]
        public void It_Should_Render_Second_Elsif()
        {
            // Act
            var result = RenderingHelper.RenderTemplate("Result : {% if false %}OK{% elsif false %}Else If{% elsif true %}second else{% else %}Else{% endif %}");

            // Assert
            Assert.That(result, Is.EqualTo("Result : second else"));
        }

        [Test]
        public void It_Should_Render_Nested_If_Statements()
        {
            // Act
            var result = RenderingHelper.RenderTemplate("Result : {% if true %}OK{% if false %}NOT OK{% endif %}{% if true %}OK{% endif %}{% endif %}");

            // Assert
            Assert.That(result, Is.EqualTo("Result : OKOK"));
        }

      
        /// <summary>
        /// https://github.com/mikebridge/Liquid.NET/wiki/Differences/
        /// </summary>
        [Test]
        public void It_Should_Group_Expressions_With_Parentheses()
        {
            // Arrange
            const string str = @"{% if (false and true) or true %}Result #1 is true{% endif %}"
                             + @"{% if false and (true or true) %}Result #2 is true{% endif %}";
            // Act
            var result = RenderingHelper.RenderTemplate(str);

            // Assert
            Assert.That(result, Is.EqualTo("Result #1 is true"));

        }

        /// <summary>
        /// https://github.com/mikebridge/Liquid.NET/wiki/Differences/
        /// </summary>
        [Test]
        public void It_Should_Allow_Not_To_Be_Used()
        {
            // Arrange
            const String txt = "not false is true!";
            const string str = @"{% if not false %}"+txt+"{% endif %}";

            // Act
            var result = RenderingHelper.RenderTemplate(str);

            // Assert
            Assert.That(result, Is.EqualTo(txt));

        }



    }
}
