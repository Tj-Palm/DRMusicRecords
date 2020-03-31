using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrMusic;
using DrMusicRecords.Controllers;
using Newtonsoft.Json;
using DrMusicRecords.Models;

namespace DrMusicUnitTest
{
    [TestClass]
    public class UnitTests
    {
        private MusicRecordsContext _context;
        private DrMusic.MusicRecords _mr;
        private MusicRecordsDTO _mrdto;
        private MusicRecordsController _controller;
        //private MusicRecordController _controller;

        [TestInitialize]
        public void Initialize()
        {
            _mr = new DrMusic.MusicRecords();
            _controller = new MusicRecordsController(_context);
            //_controller = new MusicRecordController();

            _controller.PostMusicRecords(new MusicRecordsDTO{Title = "Hej", Duration = 20, Artist = "Bo", YearOfPublication = 2020});
            _controller.PostMusicRecords(new MusicRecordsDTO{ Title = "Hej1", Duration = 20, Artist = "Bo1", YearOfPublication = 2019 });
            _controller.PostMusicRecords(new MusicRecordsDTO{ Title = "Hej2", Duration = 20, Artist = "Bo2", YearOfPublication = 2018 });
            _controller.PostMusicRecords(new MusicRecordsDTO{ Title = "Hej", Duration = 20, Artist = "Bo", YearOfPublication = 2018 });
        }

        #region MusicRecordController


        #region GetTests
        //[TestMethod]
        //public void TestGetAllCount()
        //{
        //    var musicRecord = 4;
        //    var result = _controller.GetMusicRecords(4);

        //    Assert.AreEqual(musicRecord, result);
        //}

        //[TestMethod]
        //public void TestGetByTitle()
        //{
        //    var musicRecord = "Titles";
        //    var result = _controller.GetTitleSubString("Titles").Title;

        //    Assert.AreEqual(musicRecord, result);
        //}

        //[TestMethod]
        //public void TestGetByDuration()
        //{
        //    var musicRecord = 20;
        //    var result = _controller.GetDurationSubString(20).Duration;

        //    Assert.AreEqual(musicRecord, result);
        //}

        //[TestMethod]
        //public void TestGetById()
        //{
        //    var musicRecord = 1;
        //    var result = _controller.GetById(2);

        //    Assert.AreEqual(musicRecord, result);
        //}

        //[TestMethod]
        //public void TestGetByArtist()
        //{
        //    var musicRecord = "Artist";
        //    var result = _controller.GetArtistSubString("Artist").Artist;

        //    Assert.AreEqual(musicRecord, result);
        //}

        //[TestMethod]
        //public void TestGetListArtist()
        //{
        //    var musicRercords = _;
        //    var result = _controller.GetArtistListSubstring("Artist");

        //    Assert.AreEqual(musicRercords,result);
        //}

        //[TestMethod]
        //public void TestGetByYearOfPublication()
        //{
        //    var musicRecord = 1990;
        //    var result = _controller.GetyearOfPublicationSubString(1990).YearOfPublication;

        //    Assert.AreEqual(musicRecord, result);
        //}
        #endregion

        #region PostPutDeleteTest        
        //[TestMethod]
        //public void TestPost()
        //{
        //    var musicRecords = _controller.Get().Count();
        //    _controller.Post(_mr);

        //    var result = musicRecords;
        //    Assert.AreEqual(musicRecords, result);
        //}

        //[TestMethod]
        //public void TestPut()
        //{
        //    var getMusicRecord = _controller.GetListById(2);
        //    var getOldMusicRecord = _controller.GetById(2);

        //    foreach (var item in getMusicRecord)
        //    {
        //        item.Title = "hejs";
        //        item.Artist = "Something";
        //        item.Duration = 50;
        //        item.YearOfPublication = 2020;
        //    }

        //    var getNewMusicRecord = _controller.Put(2, getMusicRecord);

        //    MusicRecords musicRecords = _controller.Put(getOldMusicRecord, getMusicRecord);
        //}

        //[TestMethod]
        //public void TestDelete()
        //{
        //    var musicRecords = _controller.Get().Count();
        //    _controller.Delete(2);
        //    var result = musicRecords;

        //    Assert.AreEqual(musicRecords, result);
        //}

        #endregion
       

        #endregion

        #region TestRecordClass

        [TestMethod]
        public void TestAfTitle()
        {
            //Arrange
            //_mr = new MusicRecords();

            //Act
            _mr.Title = "My heart will go on";

            //Assert
            Assert.AreEqual("My heart will go on", _mr.Title);

            _mr.Title = "My heart...";

            Assert.AreEqual("My heart...", _mr.Title);
        }

        [TestMethod]
        public void TestAfArtist()
        {
            //Arrange
            //_mr = new MusicRecords();

            //Act
            _mr.Artist = "Celine Dion";

            //Assert
            Assert.AreEqual("Celine Dion", _mr.Artist);
        }

        [TestMethod]
        public void TestAfDuration()
        {
            //Arrange
            //_mr = new MusicRecords();

            //Act
            _mr.Duration = 4;

            //Assert
            Assert.AreEqual(4, _mr.Duration);
        }

        [TestMethod]
        public void TestAfYearOfPublication()
        {
            //Arrange
            //_mr = new MusicRecords();

            //Act
            _mr.YearOfPublication = 1997;

            //Assert
            Assert.AreEqual(1997, _mr.YearOfPublication);
        }

        [TestMethod]
        public void TestAfID()
        {
            //Arrange
            //_mr = new MusicRecords();

            //Act
            _mr.Id = 1;

            //Assert
            Assert.AreEqual(1, _mr.Id);
        }
        #endregion

        #region MusicRecordsController Unit-Test

        [TestMethod]
        public void TestGetAllCount()
        {
            var musicRecord = 4;
            var result = _controller.GetMusicRecordsList().Result;

            Assert.AreEqual(musicRecord, result);
        }

        #endregion

    }
}
