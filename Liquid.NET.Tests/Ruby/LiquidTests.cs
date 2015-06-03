//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
//
//     Source: liquid.txt
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from Liquid.Ruby\writetest.rb
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Liquid.NET.Constants;
using NUnit.Framework;

namespace Liquid.NET.Tests.Ruby
{
    [TestFixture]
    public class LiquidTests {

        [Test]
        [TestCase(@"", @"{""choices"":[1,null,false]}")]
        [TestCase(@"", @"{""choices"":[1,null,false]}")]
        [TestCase(@"", @"{}")]
        [TestCase(@"", @"{}")]
        [TestCase(@"", @"{}")]
        [TestCase(@"", @"{}")]
        [TestCase(@"", @"{}")]
        [TestCase(@"", @"{}")]
        [TestCase(@"", @"{""thing"":{""foo"":{""bar"":42}}}")]
        [TestCase(@".# TEMPLATE
{{ foo | map: ""foo"" }}", @"123")]
        [TestCase(@"{{ 12 | divided_by:3 }}", @"4")]
        [TestCase(@"{{ 14 | divided_by:3 }}", @"4")]
        [TestCase(@"{{ 15 | divided_by:3 }}", @"5")]
        [TestCase(@"{{ 2.0 | divided_by:4 }}", @"0.5")]
        [TestCase(@"{{ 1 | modulo: 0 }}", @"")]
        [TestCase(@"{""ary"":[{""foo"":{""bar"":""a""}},{""foo"":{""bar"":""b""}},{""foo"":{""bar"":""c""}}]}", @".# TEMPLATE
{{ source | strip_newlines }}")]
        [TestCase(@"abc", @"{{ source | strip_newlines }}")]
        [TestCase(@"abc", @"{{ 'a a a a' | remove_first: 'a ' }}")]
        [TestCase(@"a a a", @"{""foo"":[""#<ThingWithToLiquid:0x000000025869c8>""]}")]
        [TestCase(@"", @"{""foo"":[""#<ThingWithToLiquid:0x00000002584560>""]}")]
        [TestCase(@"", @"{}")]
        [TestCase(@"", @"{}")]
        [TestCase(@"{{ source | newline_to_br }}", @"a<br />
b<br />
c")]
        [TestCase(@"{""source"":"" ab c  ""}", @"")]
        [TestCase(@"{""source"":"" \tab c  \n \t""}", @"..# TEMPLATE
{{ ""foo"" | map: ""__id__"" }}")]
        [TestCase(@"", @"{{ ""foo"" | map: ""inspect"" }}")]
        [TestCase(@"", @"{""input"":5,""operand"":1}")]
        [TestCase(@"", @"{}")]
        [TestCase(@"..# TEMPLATE
{{ a | append: 'd'}}", @"bcd")]
        [TestCase(@"{{ a | append: b}}", @"bcd")]
        [TestCase(@"{{ 1 | plus:1 }}", @"2")]
        [TestCase(@"{{ '1' | plus:'1.0' }}", @"2.0")]
        [TestCase(@"{{ 'foo|bar' | remove: '|' }}", @"foobar")]
        [TestCase(@"{{ 3 | times:4 }}", @"12")]
        [TestCase(@"{{ 'foo' | times:4 }}", @"0")]
        [TestCase(@"{{ '2.1' | times:3 | replace: '.','-' | plus:0}}", @"6")]
        [TestCase(@"{{ 0.0725 | times:100 }}", @"7.25")]
        [TestCase(@"{""procs"":[""#<Proc:0x000000024f6170@/home/bridge/work/liquid/test/integration/standard_filter_test.rb:215>""]}", @"..# TEMPLATE
{{ source | rstrip }}")]
        [TestCase(@"ab c", @"{{ source | rstrip }}")]
        [TestCase(@"ab c", @"{{ foo | sort: ""bar"" | map: ""foo"" }}")]
        [TestCase(@"213", @"{""input"":4.6}")]
        [TestCase(@"", @"{}")]
        [TestCase(@"", @"{}")]
        [TestCase(@"{}", @"")]
        [TestCase(@"{""input"":4.6}", @"")]
        [TestCase(@"{}", @"")]
        [TestCase(@"{""input"":4.5612}", @"")]
        [TestCase(@"{}", @"{""source"":"" ab c  ""}")]
        [TestCase(@"", @"{""source"":"" \tab c  \n \t""}")]
        [TestCase(@"..# TEMPLATE
{{ thing | map: ""foo"" | map: ""bar"" }}", @"4217")]
        [TestCase(@"{{ input | ceil }}", @"5")]
        [TestCase(@"{{ '4.3' | ceil }}", @"5")]
        [TestCase(@"{{ 1.0 | divided_by: 0.0 | ceil }}", @"")]
        [TestCase(@"{""foo"":[""woot: 0""]}", @"F# TEMPLATE
{{ a | prepend: 'a'}}")]
        [TestCase(@"abc", @"{{ a | prepend: b}}")]
        [TestCase(@"abc", @"{}")]
        [TestCase(@".........# TEMPLATE
{% capture 'var' %}test string{% endcapture %}{{var}}", @"test string")]
        [TestCase(@"{""array"":[1,1,2,2,3,3]}", @"")]
        [TestCase(@"{""array"":[1,1,1,1]}", @"")]
        [TestCase(@"{""a"":[]}", @"")]
        [TestCase(@"{""a"":[1]}", @"")]
        [TestCase(@"{""a"":[1,1]}", @"")]
        [TestCase(@"{""a"":[1,1,1]}", @"")]
        [TestCase(@"{""a"":[1,1,1,1]}", @"")]
        [TestCase(@"{""a"":[1,1,1,1,1]}", @"")]
        [TestCase(@"{""condition"":5}", @"")]
        [TestCase(@"{""condition"":6}", @"")]
        [TestCase(@"{""condition"":6}", @"")]
        [TestCase(@"{}", @"")]
        [TestCase(@"{""hash"":{""a"":1,""b"":2,""c"":3,""d"":4}}", @"")]
        [TestCase(@"{""var"":""content""}", @"{% case condition %}{% when 1 %} its 1 {% when 2 %} its 2 {% endcase %}")]
        [TestCase(@"its 2", @"{% case condition %}{% when 1 %} its 1 {% when 2 %} its 2 {% endcase %}")]
        [TestCase(@"its 1", @"{% case condition %}{% when 1 %} its 1 {% when 2 %} its 2 {% endcase %}")]
        [TestCase(@"", @"{% case condition %}{% when ""string here"" %} hit {% endcase %}")]
        [TestCase(@"hit", @"{% case condition %}{% when ""string here"" %} hit {% endcase %}")]
        [TestCase(@"", @"{% case a.empty? %}{% when true %}true{% when false %}false{% else %}else{% endcase %}")]
        [TestCase(@"else", @"{% case false %}{% when true %}true{% when false %}false{% else %}else{% endcase %}")]
        [TestCase(@"false", @"{% case true %}{% when true %}true{% when false %}false{% else %}else{% endcase %}")]
        [TestCase(@"true", @"{% case NULL %}{% when true %}true{% when false %}false{% else %}else{% endcase %}")]
        [TestCase(@"else", @"{% case a.size %}{% when 1 %}1{% when 2 %}2{% else %}else{% endcase %}")]
        [TestCase(@"else", @"{% case a.size %}{% when 1 %}1{% when 2 %}2{% else %}else{% endcase %}")]
        [TestCase(@"1", @"{% case a.size %}{% when 1 %}1{% when 2 %}2{% else %}else{% endcase %}")]
        [TestCase(@"2", @"{% case a.size %}{% when 1 %}1{% when 2 %}2{% else %}else{% endcase %}")]
        [TestCase(@"else", @"{% case a.size %}{% when 1 %}1{% when 2 %}2{% else %}else{% endcase %}")]
        [TestCase(@"else", @"{% case a.size %}{% when 1 %}1{% when 2 %}2{% else %}else{% endcase %}")]
        [TestCase(@"else", @"{% case condition %}{% when 1, 2, 3 %} its 1 or 2 or 3 {% when 4 %} its 4 {% endcase %}")]
        [TestCase(@"its 1 or 2 or 3", @"{% case condition %}{% when 1, 2, 3 %} its 1 or 2 or 3 {% when 4 %} its 4 {% endcase %}")]
        [TestCase(@"its 1 or 2 or 3", @"{% case condition %}{% when 1, 2, 3 %} its 1 or 2 or 3 {% when 4 %} its 4 {% endcase %}")]
        [TestCase(@"its 1 or 2 or 3", @"{% case condition %}{% when 1, 2, 3 %} its 1 or 2 or 3 {% when 4 %} its 4 {% endcase %}")]
        [TestCase(@"its 4", @"{% case condition %}{% when 1, 2, 3 %} its 1 or 2 or 3 {% when 4 %} its 4 {% endcase %}")]
        [TestCase(@"", @"{% case condition %}{% when 1, ""string"", null %} its 1 or 2 or 3 {% when 4 %} its 4 {% endcase %}")]
        [TestCase(@"its 1 or 2 or 3", @"{% case condition %}{% when 1, ""string"", null %} its 1 or 2 or 3 {% when 4 %} its 4 {% endcase %}")]
        [TestCase(@"its 1 or 2 or 3", @"{% case condition %}{% when 1, ""string"", null %} its 1 or 2 or 3 {% when 4 %} its 4 {% endcase %}")]
        [TestCase(@"its 1 or 2 or 3", @"{% case condition %}{% when 1, ""string"", null %} its 1 or 2 or 3 {% when 4 %} its 4 {% endcase %}")]
        [TestCase(@"", @"{% assign a = ""variable""%}{{a}}")]
        [TestCase(@"variable", @"{%cycle ""one"", ""two""%}")]
        [TestCase(@"one", @"{%cycle ""one"", ""two""%} {%cycle ""one"", ""two""%}")]
        [TestCase(@"one two", @"{%cycle """", ""two""%} {%cycle """", ""two""%}")]
        [TestCase(@"two", @"{%cycle ""one"", ""two""%} {%cycle ""one"", ""two""%} {%cycle ""one"", ""two""%}")]
        [TestCase(@"one two one", @"{%cycle ""text-align: left"", ""text-align: right"" %} {%cycle ""text-align: left"", ""text-align: right""%}")]
        [TestCase(@"text-align: left text-align: right", @"{% case condition %}{% when 1 or 2 or 3 %} its 1 or 2 or 3 {% when 4 %} its 4 {% endcase %}")]
        [TestCase(@"its 1 or 2 or 3", @"{% case condition %}{% when 1 or 2 or 3 %} its 1 or 2 or 3 {% when 4 %} its 4 {% endcase %}")]
        [TestCase(@"its 1 or 2 or 3", @"{% case condition %}{% when 1 or 2 or 3 %} its 1 or 2 or 3 {% when 4 %} its 4 {% endcase %}")]
        [TestCase(@"its 1 or 2 or 3", @"{% case condition %}{% when 1 or 2 or 3 %} its 1 or 2 or 3 {% when 4 %} its 4 {% endcase %}")]
        [TestCase(@"its 4", @"{% case condition %}{% when 1 or 2 or 3 %} its 1 or 2 or 3 {% when 4 %} its 4 {% endcase %}")]
        [TestCase(@"", @"{% case condition %}{% when 1 or ""string"" or null %} its 1 or 2 or 3 {% when 4 %} its 4 {% endcase %}")]
        [TestCase(@"its 1 or 2 or 3", @"{% case condition %}{% when 1 or ""string"" or null %} its 1 or 2 or 3 {% when 4 %} its 4 {% endcase %}")]
        [TestCase(@"its 1 or 2 or 3", @"{% case condition %}{% when 1 or ""string"" or null %} its 1 or 2 or 3 {% when 4 %} its 4 {% endcase %}")]
        [TestCase(@"its 1 or 2 or 3", @"{% case condition %}{% when 1 or ""string"" or null %} its 1 or 2 or 3 {% when 4 %} its 4 {% endcase %}")]
        [TestCase(@"", @"the comment block should be removed {%comment%} be gone.. {%endcomment%} .. right?")]
        [TestCase(@"the comment block should be removed  .. right?", @"{%comment%}{%endcomment%}")]
        [TestCase(@"", @"{%comment%}{% endcomment %}")]
        [TestCase(@"", @"{% comment %}{%endcomment%}")]
        [TestCase(@"", @"{% comment %}{% endcomment %}")]
        [TestCase(@"", @"{%comment%}comment{%endcomment%}")]
        [TestCase(@"", @"{% comment %}comment{% endcomment %}")]
        [TestCase(@"", @"{% comment %} 1 {% comment %} 2 {% endcomment %} 3 {% endcomment %}")]
        [TestCase(@"", @"{%comment%}{%blabla%}{%endcomment%}")]
        [TestCase(@"", @"{% comment %}{% blabla %}{% endcomment %}")]
        [TestCase(@"", @"{%comment%}{% endif %}{%endcomment%}")]
        [TestCase(@"", @"{% comment %}{% endwhatever %}{% endcomment %}")]
        [TestCase(@"", @"{% comment %}{% raw %} {{%%%%}}  }} { {% endcomment %} {% comment {% endraw %} {% endcomment %}")]
        [TestCase(@"", @"foo{%comment%}comment{%endcomment%}bar")]
        [TestCase(@"foobar", @"foo{% comment %}comment{% endcomment %}bar")]
        [TestCase(@"foobar", @"foo{%comment%} comment {%endcomment%}bar")]
        [TestCase(@"foobar", @"foo{% comment %} comment {% endcomment %}bar")]
        [TestCase(@"foobar", @"foo {%comment%} {%endcomment%} bar")]
        [TestCase(@"foo  bar", @"foo {%comment%}comment{%endcomment%} bar")]
        [TestCase(@"foo  bar", @"foo {%comment%} comment {%endcomment%} bar")]
        [TestCase(@"foo  bar", @"foo{%comment%}
                                     {%endcomment%}bar")]
        [TestCase(@"foobar", @"{%assign var2 = var[""a:b c""].paged %}var2: {{var2}}")]
        [TestCase(@"var2: 1", @"{%cycle var1: ""one"", ""two"" %} {%cycle var2: ""one"", ""two"" %} {%cycle var1: ""one"", ""two"" %} {%cycle var2: ""one"", ""two"" %} {%cycle var1: ""one"", ""two"" %} {%cycle var2: ""one"", ""two"" %}")]
        [TestCase(@"one one two two one one", @"this text should come out of the template without change...")]
        [TestCase(@"this text should come out of the template without change...", @"blah")]
        [TestCase(@"blah", @"<blah>")]
        [TestCase(@"<blah>", @"|,.:")]
        [TestCase(@"|,.:", @"")]
        [TestCase(@"", @"this shouldnt see any transformation either but has multiple lines
              as you can clearly see here ...")]
        [TestCase(@"this shouldnt see any transformation either but has multiple lines
              as you can clearly see here ...", @"{% assign a = """"%}{{a}}")]
        [TestCase(@"", @"{% case false %}{% when %}true{% endcase %}")]
        [TestCase(@"", @"{}")]
        [TestCase(@"{% if true == empty %}?{% endif %}", @"")]
        [TestCase(@"{% if true == null %}?{% endif %}", @"")]
        [TestCase(@"{% if empty == true %}?{% endif %}", @"")]
        [TestCase(@"{% if null == true %}?{% endif %}", @"")]
        [TestCase(@"0{%
for i in (1..3)
%} {{
i
}}{%
endfor
%}", @"0 1 2 3")]
        [TestCase(@"{%cycle 1,2%} {%cycle 1,2%} {%cycle 1,2%} {%cycle 1,2,3%} {%cycle 1,2,3%} {%cycle 1,2,3%} {%cycle 1,2,3%}", @"1 2 1 1 2 3 1")]
        [TestCase(@"{}", @"")]
        [TestCase(@"{""var"":""content""}", @"")]
        [TestCase(@"{""var"":""content""}", @"")]
        [TestCase(@"{""a-b"":""1""}", @"")]
        [TestCase(@"{""array"":[1,2,3,4]}", @"")]
        [TestCase(@"{}", @"")]
        [TestCase(@"{""var"":null}", @"")]
        [TestCase(@"{""var"":null}", @"")]
        [TestCase(@"{}", @"")]
        [TestCase(@"{}", @"")]
        [TestCase(@"{}", @"")]
        [TestCase(@"{}", @"")]
        [TestCase(@"{}", @"")]
        [TestCase(@"{}", @"")]
        [TestCase(@"{}", @"")]
        [TestCase(@"{""var"":""hello there!""}", @"")]
        [TestCase(@"{""array"":[1,2,3]}", @"")]
        [TestCase(@"{""var"":""hello there!""}", @"")]
        [TestCase(@"{}", @"")]
        [TestCase(@"{}", @"")]
        [TestCase(@"{}", @"")]
        [TestCase(@"{""var"":""hello there!""}", @"")]
        [TestCase(@"{""array"":[]}", @"")]
        [TestCase(@"{""var"":1}", @"")]
        [TestCase(@"{""var"":1}", @"")]
        [TestCase(@"{""var"":""hello there!""}", @"..............# TEMPLATE
{% raw %} Foobar {% invalid {% endraw %}")]
        [TestCase(@"Foobar {% invalid", @"{% raw %} Foobar invalid %} {% endraw %}")]
        [TestCase(@"Foobar invalid %}", @"{% raw %} Foobar {{ invalid {% endraw %}")]
        [TestCase(@"Foobar {{ invalid", @"{% raw %} Foobar invalid }} {% endraw %}")]
        [TestCase(@"Foobar invalid }}", @"{% raw %} Foobar {% invalid {% {% endraw {% endraw %}")]
        [TestCase(@"Foobar {% invalid {% {% endraw", @"{% raw %} Foobar {% {% {% {% endraw %}")]
        [TestCase(@"Foobar {% {% {%", @"{% raw %} test {% raw %} {% {% endraw %}endraw %}")]
        [TestCase(@"test {% raw %} {% endraw %}", @"{% raw %} Foobar {{ invalid {% endraw %}{{ 1 }}")]
        [TestCase(@"Foobar {{ invalid 1", @"{% raw %}{% comment %} test {% endcomment %}{% endraw %}")]
        [TestCase(@"{% comment %} test {% endcomment %}", @"{% raw %}{{ test }}{% endraw %}")]
        [TestCase(@"{{ test }}", @"{""foo"":""#<ThingWithToLiquid:0x00000001bfdc08>""}")]
        [TestCase(@".....................................................................................# TEMPLATE
{% tablerow n in numbers cols:3%} {{n}} {% endtablerow %}", @"<tr class=""row1"">
<td class=""col1""> 1 </td><td class=""col2""> 2 </td><td class=""col3""> 3 </td></tr>
<tr class=""row2""><td class=""col1""> 4 </td><td class=""col2""> 5 </td><td class=""col3""> 6 </td></tr>")]
        [TestCase(@"{% tablerow n in numbers cols:3 offset:1 limit:6%} {{n}} {% endtablerow %}", @"<tr class=""row1"">
<td class=""col1""> 1 </td><td class=""col2""> 2 </td><td class=""col3""> 3 </td></tr>
<tr class=""row2""><td class=""col1""> 4 </td><td class=""col2""> 5 </td><td class=""col3""> 6 </td></tr>")]
        [TestCase(@"{% tablerow n in collections.frontpage cols:3%} {{n}} {% endtablerow %}", @"<tr class=""row1"">
<td class=""col1""> 1 </td><td class=""col2""> 2 </td><td class=""col3""> 3 </td></tr>
<tr class=""row2""><td class=""col1""> 4 </td><td class=""col2""> 5 </td><td class=""col3""> 6 </td></tr>")]
        [TestCase(@"{% tablerow n in collections['frontpage'] cols:3%} {{n}} {% endtablerow %}", @"<tr class=""row1"">
<td class=""col1""> 1 </td><td class=""col2""> 2 </td><td class=""col3""> 3 </td></tr>
<tr class=""row2""><td class=""col1""> 4 </td><td class=""col2""> 5 </td><td class=""col3""> 6 </td></tr>")]
        [TestCase(@"{% tablerow n in numbers cols:3%} {{n}} {% endtablerow %}", @"<tr class=""row1"">
<td class=""col1""> 1 </td><td class=""col2""> 2 </td><td class=""col3""> 3 </td></tr>
<tr class=""row2""><td class=""col1""> 4 </td><td class=""col2""> 5 </td><td class=""col3""> 6 </td></tr>")]
        [TestCase(@"{% tablerow n in numbers cols:3%} {{n}} {% endtablerow %}", @"<tr class=""row1"">
</tr>")]
        [TestCase(@"{% tablerow n in numbers cols:5%} {{n}} {% endtablerow %}", @"<tr class=""row1"">
<td class=""col1""> 1 </td><td class=""col2""> 2 </td><td class=""col3""> 3 </td><td class=""col4""> 4 </td><td class=""col5""> 5 </td></tr>
<tr class=""row2""><td class=""col1""> 6 </td></tr>")]
        [TestCase(@"{% tablerow char in characters cols:3 %}I WILL NOT BE OUTPUT{% endtablerow %}", @"<tr class=""row1"">
</tr>")]
        [TestCase(@"{% tablerow n in numbers cols:2%}{{tablerowloop.col}}{% endtablerow %}", @"<tr class=""row1"">
<td class=""col1"">1</td><td class=""col2"">2</td></tr>
<tr class=""row2""><td class=""col1"">1</td><td class=""col2"">2</td></tr>
<tr class=""row3""><td class=""col1"">1</td><td class=""col2"">2</td></tr>")]
        [TestCase(@"{}", @"")]
        [TestCase(@"{}", @"")]
        [TestCase(@"{}", @"")]
        [TestCase(@"{}", @"")]
        [TestCase(@"{}", @"")]
        [TestCase(@"{}", @"")]
        [TestCase(@"{}", @"")]
        [TestCase(@"{}", @"")]
        [TestCase(@"{}", @"")]
        [TestCase(@"{}", @"")]
        [TestCase(@"{}", @"")]
        [TestCase(@"{}", @"")]
        [TestCase(@"{}", @"")]
        [TestCase(@"{}", @"")]
        [TestCase(@"{}", @"")]
        [TestCase(@"{}", @"")]
        [TestCase(@"{}", @"")]
        [TestCase(@"{}", @"")]
        [TestCase(@"{}", @"")]
        [TestCase(@"{}", @"")]
        [TestCase(@"{}", @"")]
        [TestCase(@"{}", @"................# TEMPLATE
{% continue %}")]
        [TestCase(@"", @"{% break %}")]
        [TestCase(@"", @"{""products"":[{""title"":""Draft 151cm""},{""title"":""Element 155cm""}]}")]
        [TestCase(@"", @"{}")]
        [TestCase(@"", @"{}")]
        [TestCase(@"", @"{""echo1"":""test123"",""more_echos"":{""echo2"":""test321""}}")]
        [TestCase(@"", @"{}")]
        [TestCase(@".# TEMPLATE
{% include template %}", @"Test123")]
        [TestCase(@"{% include template %}", @"Test321")]
        [TestCase(@"{% include template for product %}", @"Product: Draft 151cm")]
        [TestCase(@"{""product"":{""title"":""Draft 151cm""}}", @".# TEMPLATE
{% include 'assignments' %}{{ foo }}")]
        [TestCase(@"bar", @"{% assign page = 'pick_a_source' %}{% include page %}")]
        [TestCase(@"from TestFileSystem", @"{% assign page = 'product' %}{% include page %}")]
        [TestCase(@"Product: Draft 151cm", @"{% assign page = 'product' %}{% include page for foo %}")]
        [TestCase(@"Product: Draft 151cm", @"{% include 'body' %}")]
        [TestCase(@"body body_detail", @"{% include 'nested_template' %}")]
        [TestCase(@"header body body_detail footer", @"{% include 'nested_product_template' with product %}")]
        [TestCase(@"Product: Draft 151cm details", @"{% include 'nested_product_template' for products %}")]
        [TestCase(@"Product: Draft 151cm details Product: Element 155cm details", @"{""products"":[{""title"":""Draft 151cm""},{""title"":""Element 155cm""}]}")]
        [TestCase(@"........................................# TEMPLATE
{% assign foo = values %}.{{ foo[0] }}.", @".foo.")]
        [TestCase(@"{% assign foo = values %}.{{ foo[1] }}.", @".bar.")]
        [TestCase(@"{% assign foo = values | split: "","" %}.{{ foo[1] }}.", @".bar.")]
        [TestCase(@"{""a"":""and"",""b"":""or"",""c"":""foo and bar"",""d"":""bar or baz"",""e"":""foo"",""foo"":true,""bar"":true}", @"")]
        [TestCase(@"{""a"":true,""b"":true}", @"")]
        [TestCase(@"{""a"":true,""b"":false}", @"")]
        [TestCase(@"{""a"":false,""b"":true}", @"")]
        [TestCase(@"{""a"":false,""b"":false}", @"")]
        [TestCase(@"{""a"":false,""b"":false,""c"":true}", @"")]
        [TestCase(@"{""a"":false,""b"":false,""c"":false}", @"")]
        [TestCase(@"{}", @"")]
        [TestCase(@"{}", @"")]
        [TestCase(@"{}", @"")]
        [TestCase(@"{}", @"")]
        [TestCase(@"{}", @"")]
        [TestCase(@"{}", @"")]
        [TestCase(@"{}", @"")]
        [TestCase(@"{""order"":{""items_count"":0},""android"":{""name"":""Roy""}}", @"")]
        [TestCase(@"{""order"":{""items_count"":0},""android"":{""name"":""Roy""}}", @"")]
        [TestCase(@"{}", @"")]
        [TestCase(@"{}", @"")]
        [TestCase(@"{}", @"")]
        [TestCase(@"{}", @"")]
        [TestCase(@"{}", @"{% if 'gnomeslab-and-or-liquid' contains 'gnomeslab-and-or-liquid' %}yes{% endif %}")]
        [TestCase(@"yes", @"{% if jerry == 1 %}")]
        [TestCase(@"", @"{}")]
        [TestCase(@"", @"{}")]
        [TestCase(@"", @"{}")]
        [TestCase(@"", @"{}")]
        [TestCase(@"", @"{}")]
        [TestCase(@"", @"{}")]
        [TestCase(@"", @"{}")]
        [TestCase(@"", @"{}")]
        [TestCase(@"", @"{}")]
        [TestCase(@"", @"{}")]
        [TestCase(@"", @"{}")]
        [TestCase(@"", @"{}")]
        [TestCase(@"", @"{}")]
        [TestCase(@"", @"{""foo"":{}}")]
        [TestCase(@"", @"{}")]
        [TestCase(@"{% if var %} YES {% endif %}", @"YES")]
        [TestCase(@"{% if a or b and c %}true{% else %}false{% endif %}", @"true")]
        [TestCase(@"{% if a or b and c %}true{% else %}false{% endif %}", @"true")]
        [TestCase(@"{% if a or b and c %}true{% else %}false{% endif %}", @"true")]
        [TestCase(@"{% if a or b and c %}true{% else %}false{% endif %}", @"true")]
        [TestCase(@"{% if a or b and c %}true{% else %}false{% endif %}", @"true")]
        [TestCase(@"{% if a or b and c %}true{% else %}false{% endif %}", @"false")]
        [TestCase(@"{% if a or b and c %}true{% else %}false{% endif %}", @"false")]
        [TestCase(@"{% if a or b and c %}true{% else %}false{% endif %}", @"false")]
        [TestCase(@"{% if false %} this text should not go into the output {% endif %}", @"")]
        [TestCase(@"{% if true %} this text should go into the output {% endif %}", @"this text should go into the output")]
        [TestCase(@"{% if false %} you suck {% endif %} {% if true %} you rock {% endif %}?", @"you rock ?")]
        [TestCase(@"{% if a == true or b == true %} YES {% endif %}", @"YES")]
        [TestCase(@"{% if a == true or b == false %} YES {% endif %}", @"YES")]
        [TestCase(@"{% if a == false or b == false %} YES {% endif %}", @"")]
        [TestCase(@"{% if var %} NO {% endif %}", @"")]
        [TestCase(@"{% if var %} NO {% endif %}", @"")]
        [TestCase(@"{% if foo.bar %} NO {% endif %}", @"")]
        [TestCase(@"{% if foo.bar %} NO {% endif %}", @"")]
        [TestCase(@"{% if foo.bar %} NO {% endif %}", @"")]
        [TestCase(@"{% if foo.bar %} NO {% endif %}", @"")]
        [TestCase(@"{% if var %} YES {% endif %}", @"YES")]
        [TestCase(@"{% if var %} YES {% endif %}", @"YES")]
        [TestCase(@"{% if var %} YES {% endif %}", @"YES")]
        [TestCase(@"{% if var %} YES {% endif %}", @"YES")]
        [TestCase(@"{% if var %} YES {% endif %}", @"YES")]
        [TestCase(@"{% if ""foo"" %} YES {% endif %}", @"YES")]
        [TestCase(@"{% if foo.bar %} YES {% endif %}", @"YES")]
        [TestCase(@"{% if foo.bar %} YES {% endif %}", @"YES")]
        [TestCase(@"{% if foo.bar %} YES {% endif %}", @"YES")]
        [TestCase(@"{% if foo.bar %} YES {% endif %}", @"YES")]
        [TestCase(@"{% if foo.bar %} YES {% endif %}", @"YES")]
        [TestCase(@"{% if var %} NO {% else %} YES {% endif %}", @"YES")]
        [TestCase(@"{% if var %} NO {% else %} YES {% endif %}", @"YES")]
        [TestCase(@"{% if var %} YES {% else %} NO {% endif %}", @"YES")]
        [TestCase(@"{% if ""foo"" %} YES {% else %} NO {% endif %}", @"YES")]
        [TestCase(@"{% if foo.bar %} NO {% else %} YES {% endif %}", @"YES")]
        [TestCase(@"{% if foo.bar %} YES {% else %} NO {% endif %}", @"YES")]
        [TestCase(@"{% if foo.bar %} YES {% else %} NO {% endif %}", @"YES")]
        [TestCase(@"{% if foo.bar %} NO {% else %} YES {% endif %}", @"YES")]
        [TestCase(@"{% if foo.bar %} NO {% else %} YES {% endif %}", @"YES")]
        [TestCase(@"{% if foo.bar %} NO {% else %} YES {% endif %}", @"YES")]
        [TestCase(@"{% if true and true %} YES {% endif %}", @"YES")]
        [TestCase(@"{% if false and true %} YES {% endif %}", @"")]
        [TestCase(@"{% if false and true %} YES {% endif %}", @"")]
        [TestCase(@"{% assign v = false %}{% if v %} YES {% else %} NO {% endif %}", @"NO")]
        [TestCase(@"{% assign v = nil %}{% if v == nil %} YES {% else %} NO {% endif %}", @"YES")]
        [TestCase(@"{""port"":10}", @"F# TEMPLATE
{%increment port %}")]
        [TestCase(@"0", @"{""b"":""bar"",""c"":""baz""}")]
        [TestCase(@".# TEMPLATE
{% if true && false %} YES {% endif %}", @"YES")]
        [TestCase(@"{% if false || true %} YES {% endif %}", @"")]
        [TestCase(@"{}", @"")]
        [TestCase(@"{}", @".....# TEMPLATE
{% for i in (1...5) %}{{ i }}{% endfor %}")]
        [TestCase(@"12345", @"{{ 'hi there' | split$$$:' ' | first }}")]
        [TestCase(@"hi", @"{{ 'X' | downcase) }}")]
        [TestCase(@"x", @"{{ 'hi there' | split:""t"""" | reverse | first}}")]
        [TestCase(@"here", @"{{ 'hi there' | split:""t"""" | remove:""i"" | first}}")]
        [TestCase(@"hi", @"{""foobar"":{""value"":3}}")]
        [TestCase(@"", @"{""items"":""ForTagTest::LoaderDrop""}")]
        [TestCase(@"", @"{""array"":{""items"":[1,2,3,4,5,6,7,8,9,0]}}")]
        [TestCase(@"", @"{""array"":[1,2,3,4,5,6,7,8,9,0],""limit"":2,""offset"":2}")]
        [TestCase(@"", @"{""outer"":[[1,1,1],[1,1,1]]}")]
        [TestCase(@"", @"{}")]
        [TestCase(@"", @"{""array"":{""items"":[1,2,3,4,5]}}")]
        [TestCase(@"", @"{""array"":{""items"":[1,2,3,4,5]}}")]
        [TestCase(@"", @"{""array"":{""items"":[1,2,3,4,5]}}")]
        [TestCase(@"", @"{""array"":{""items"":[1,2,3,4,5]}}")]
        [TestCase(@"", @"{""array"":{""items"":[1,2,3,4,5]}}")]
        [TestCase(@"", @"{""array"":[[1,2],[3,4],[5,6]]}")]
        [TestCase(@"", @"{""array"":{""items"":[1,2,3,4,5]}}")]
        [TestCase(@"", @"{""array"":[1,2,3]}")]
        [TestCase(@"", @"{""array"":[1,2,3]}")]
        [TestCase(@"", @"{""array"":[1,2,3]}")]
        [TestCase(@"", @"{""array"":[""a"",""b"",""c"",""d""]}")]
        [TestCase(@"", @"{""array"":[""a"","" "",""b"","" "",""c""]}")]
        [TestCase(@"", @"{""array"":[""a"","""",""b"","""",""c""]}")]
        [TestCase(@"", @"{""array"":[1,2,3,4,5,6,7,8,9,0]}")]
        [TestCase(@"", @"{""array"":[1,2,3,4,5,6,7,8,9,0]}")]
        [TestCase(@"", @"{""array"":[1,2,3,4,5,6,7,8,9,0]}")]
        [TestCase(@"", @"{""array"":[1,2,3,4,5,6,7,8,9,0]}")]
        [TestCase(@"", @"{""array"":[[1,2],[3,4],[5,6]]}")]
        [TestCase(@"", @"{""array"":[1,2,3]}")]
        [TestCase(@"", @"{""array"":{""items"":[1,2,3,4,5,6,7,8,9,0]}}")]
        [TestCase(@".# TEMPLATE
{% for item in items %}{{item}}{% endfor %}", @"12345")]
        [TestCase(@"{%for item in (1..foobar.value) %} {{item}} {%endfor%}", @"1  2  3")]
        [TestCase(@"{% for item in items limit:1 %}{{item}}{% endfor %}", @"1")]
        [TestCase(@"{% for       item   in   items %}{{item}}{% endfor %}", @"12345")]
        [TestCase(@"{% for item in items offset:2 limit:2 %}{{item}}{% endfor %}", @"34")]
        [TestCase(@"{% for item in items offset:2 limit:2 %}{{item}}{% endfor %}", @"34")]
        [TestCase(@"{%for i in array.items limit:3 %}{{i}}{%endfor%}
      next
      {%for i in array.items offset:continue limit:3 %}{{i}}{%endfor%}
      next
      {%for i in array.items offset:continue limit:3 offset:1000 %}{{i}}{%endfor%}", @"123
      next
      456
      next")]
        [TestCase(@"{% for char in characters %}I WILL NOT BE OUTPUT{% endfor %}", @"")]
        [TestCase(@"{%for item in array%} {{forloop.index}}/{{forloop.length}} {%endfor%}", @"1/3  2/3  3/3")]
        [TestCase(@"{%for item in array%} {{forloop.index}} {%endfor%}", @"1  2  3")]
        [TestCase(@"{%for item in array%} {{forloop.index0}} {%endfor%}", @"0  1  2")]
        [TestCase(@"{%for item in array%} {{forloop.rindex0}} {%endfor%}", @"2  1  0")]
        [TestCase(@"{%for item in array%} {{forloop.rindex}} {%endfor%}", @"3  2  1")]
        [TestCase(@"{%for item in array%} {{forloop.first}} {%endfor%}", @"true  false  false")]
        [TestCase(@"{%for item in array%} {{forloop.last}} {%endfor%}", @"false  false  true")]
        [TestCase(@"{% for inner in outer %}{% for k in inner %}{{ forloop.parentloop.index }}.{{ forloop.index }} {% endfor %}{% endfor %}", @"1.1 1.2 1.3 2.1 2.2 2.3")]
        [TestCase(@"{%for i in array offset:7 %}{{ i }}{%endfor%}", @"890")]
        [TestCase(@"{%for item in (1..3) %} {{item}} {%endfor%}", @"1  2  3")]
        [TestCase(@"{%for val in string%}{{val}}{%endfor%}", @"test string")]
        [TestCase(@"{%for val in string limit:1%}{{val}}{%endfor%}", @"test string")]
        [TestCase(@"{%for val in string%}{{forloop.name}}-{{forloop.index}}-{{forloop.length}}-{{forloop.index0}}-{{forloop.rindex}}-{{forloop.rindex0}}-{{forloop.first}}-{{forloop.last}}-{{val}}{%endfor%}", @"val-string-1-1-0-1-0-true-true-test string")]
        [TestCase(@"{%for i in array.items limit: 3 %}{{i}}{%endfor%}
      next
      {%for i in array.items offset:continue limit: 3 %}{{i}}{%endfor%}
      next
      {%for i in array.items offset:continue limit: 3 %}{{i}}{%endfor%}", @"123
      next
      456
      next
      789")]
        [TestCase(@"{%for item in array%} yo {%endfor%}", @"yo  yo  yo  yo")]
        [TestCase(@"{%for item in array%}yo{%endfor%}", @"yoyo")]
        [TestCase(@"{%for item in array%} yo {%endfor%}", @"yo")]
        [TestCase(@"{%for item in array%}{%endfor%}", @"")]
        [TestCase(@"{%for item in array%}
  yo
{%endfor%}", @"yo

  yo

  yo")]
        [TestCase(@"{%for item in array%}+{%else%}-{%endfor%}", @"+++")]
        [TestCase(@"{%for item in array%}+{%else%}-{%endfor%}", @"-")]
        [TestCase(@"{%for item in array%}+{%else%}-{%endfor%}", @"-")]
        [TestCase(@"{% for i in array.items %}{% break %}{% endfor %}", @"")]
        [TestCase(@"{% for i in array.items %}{{ i }}{% break %}{% endfor %}", @"1")]
        [TestCase(@"{% for i in array.items %}{% break %}{{ i }}{% endfor %}", @"")]
        [TestCase(@"{% for i in array.items %}{{ i }}{% if i > 3 %}{% break %}{% endif %}{% endfor %}", @"1234")]
        [TestCase(@"{% for item in array %}{% for i in item %}{% if i == 1 %}{% break %}{% endif %}{{ i }}{% endfor %}{% endfor %}", @"3456")]
        [TestCase(@"{% for i in array.items %}{% if i == 9999 %}{% break %}{% endif %}{{ i }}{% endfor %}", @"12345")]
        [TestCase(@"{%for item in (1..foobar) %} {{item}} {%endfor%}", @"1  2  3")]
        [TestCase(@"{%for item in array%}{% if forloop.first %}+{% else %}-{% endif %}{%endfor%}", @"+--")]
        public void It_Should_Match_Ruby_Output(String input, String expected) {

            // Arrange
            ITemplateContext ctx = new TemplateContext().WithAllFilters();
            var template = LiquidTemplate.Create(input);
        
            // Act
            String result = template.Render(ctx);
        
            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        
    }
}
