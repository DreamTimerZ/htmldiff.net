﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Test.HtmlDiff
{
    [TestFixture]
    public class HtmlDiffSpecTests
    {
        // Shamelessly copied specs from here with a few modifications: https://github.com/myobie/htmldiff/blob/master/spec/htmldiff_spec.rb
        [TestCase("a word is here", "a nother word is there", "a<ins class='diffins'> nother</ins> word is <del class='diffmod'>here</del><ins class='diffmod'>there</ins>")]
        [TestCase("a c", "a b c", "a <ins class='diffins'>b </ins>c")]
        [TestCase("a b c", "a c", "a <del class='diffdel'>b </del>c")]
        [TestCase("a b c", "a d c", "a <del class='diffmod'>b</del><ins class='diffmod'>d</ins> c")]
        [TestCase("<a title='xx'>test</a>", "<a title='yy'>test</a>", "<a title='yy'>test</a>")]
        // TODO: Don't speak Chinese, this needs to be validated
        [TestCase("这个是中文内容, CSharp is the bast", "这是中国语内容，CSharp is the best language.", "这<del class='diffdel'>个</del>是中<del class='diffmod'>文</del><ins class='diffmod'>国语</ins>内容<del class='diffmod'>, CSharp</del><ins class='diffmod'>，CSharp</ins> is the <del class='diffmod'>bast</del><ins class='diffmod'>best language.</ins>")]
        public void Execute_WithStandardSpecs_OutputVerified(string oldtext, string newText, string delta)
        {
            Assert.AreEqual(delta, Helpers.HtmlDiff.Execute(oldtext, newText));
        }
    }
}
