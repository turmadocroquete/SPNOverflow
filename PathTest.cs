using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using te404;

namespace WilWestTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void path_constructor_returns_list()
        {
            North n = new North();
            South s = new South();
            West w = new West();
            East e = new East();

            List<Direc> directions = new List<Direc>() { n,s,s,e,w,n,w };
            
            Path p = new Path(directions);

            //Assert.AreEqual(p.Directions, p);
        }
        [TestMethod]
        public void path_reduces_redundant_directions()
        {
            North n = new North();
            South s = new South();
            West w = new West();
            East e = new East();

            List<Direc> directions = new List<Direc>() { n, s, s, e, w, n, w };

            Path p = new Path(directions);
            p.DirReduc();

            List<Direc> expected = new List<Direc>() { w};
            Assert.IsTrue(Enumerable.SequenceEqual(p.Directions, expected);
        }
    }
}
