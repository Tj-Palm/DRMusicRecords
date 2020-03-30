using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrMusic;
using DrMusicRecords.Controllers;
using Newtonsoft.Json;

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

        #region GetTests
        [TestMethod]
        public void TestGetAllCount()
        {
            var musicRecord = 4;
            var result = _controller.Get().Count();

            Assert.AreEqual(musicRecord, result);
        }

        [TestMethod]
        public void TestGetByTitle()
        {
            var musicRecord = "Titles";
            var result = _controller.GetTitleSubString("Titles").Title;

            Assert.AreEqual(musicRecord, result);
        }

        [TestMethod]
        public void TestGetByDuration()
        {
            var musicRecord = 20;
            var result = _controller.GetDurationSubString(20).Duration;

            Assert.AreEqual(musicRecord, result);
        }

        [TestMethod]
        public void TestGetById()
        {
            var musicRecord = 1;
            var result = _controller.Get(1).Id;

            Assert.AreEqual(musicRecord, result);
        }

        [TestMethod]
        public void TestGetByArtist()
        {
            var musicRecord = "Artist";
            var result = _controller.GetArtistSubString("Artist").Artist;

            Assert.AreEqual(musicRecord, result);
        }

        [TestMethod]
        public void TestGetByYearOfPublication()
        {
            var musicRecord = 1990;
            var result = _controller.GetyearOfPublicationSubString(1990).YearOfPublication;

            Assert.AreEqual(musicRecord, result);
        }
        #endregion

        #region PostPutDeleteTest        
        [TestMethod]
        public void TestPost()
        {
            var musicRecords = _controller.Get().Count();
            _controller.Post(_mr);

            var result = musicRecords;
            Assert.AreEqual(musicRecords, result);
        }

        [TestMethod]
        public void TestPut()
        {
            var getMusicRecord = _controller.GetListById(2);
            var getOldMusicRecord = _controller.GetById(2);

            foreach (var item in getMusicRecord)
            {
                item.Title = "hejs";
                item.Artist = "Something";
                item.Duration = 50;
                item.YearOfPublication = 2020;
            }

            var getNewMusicRecord = _controller.Put(2, getMusicRecord);
            
            MusicRecords musicRecords = _controller.Put(getOldMusicRecord, getMusicRecord);
        }

        [TestMethod]
        public void TestDelete()
        {
            var musicRecords = _controller.Get().Count();
            _controller.Delete(2);
            var result = musicRecords;

            Assert.AreEqual(musicRecords, result);
        }

        #endregion

        #region TestRecordClass

        [TestMethod]
        public void TestForfatter()
        {
            //Arrange
            //_mr = new MusicRecords();

            //Act
            _mr.Titel = "My heart will go on";

            //Assert
            Assert.AreEqual("My heart will go on", _mr.Titel);

            _bog.Forfatter = "Anders B";

            Assert.AreEqual("Anders B", _bog.Forfatter);
        }

        #endregion

    }
}
