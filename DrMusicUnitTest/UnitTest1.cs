using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrMusic;
using DrMusicRecords.Controllers;

namespace DrMusicUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private MusicRecords _mr;
        private MusicRecordController _controller;


        [TestInitialize]
        public void Initialize()
        {
            _mr = new MusicRecords();
            _controller = new MusicRecordController();
        }

        [TestMethod]
        public void TestGetAllCount()
        {
            var musicRecord = 4; /*= new MusicRecords("Title", "Artist", 20, 1990);*/
            var result = _controller.Get().Count();

            Assert.AreEqual(musicRecord, result);
        }

        [TestMethod]
        public void TestGetByTitle()
        {
            var musicRecord = "Titles";
            var result = _controller.GetTitleSubString("/Title/Titles");

            Assert.AreEqual(musicRecord, result);
        }
    }
}
