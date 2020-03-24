using System.Collections.Generic;
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
        public void TestGetAll()
        {
            var musicRecord = _controller; /*= new MusicRecords("Title", "Artist", 20, 1990);*/
            var controller = _controller.Get();

            var result = controller;

            Assert.AreEqual(musicRecord, result);
        }
    }
}
