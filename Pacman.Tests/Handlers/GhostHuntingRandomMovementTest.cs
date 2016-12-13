namespace Pacman.Tests.Handlers
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Interfaces;
    using Moq;
    using Pacman.Handlers;
    using Globals;
    using Models;

    [TestClass]
    public class GhostHuntingRandomMovementTest
    {
        GhostHuntingRandomMovement randMovement;

        [TestInitialize]
        public void Test()
        {
            var ghostMock = new Mock<Models.LevelObjects.Ghost>();
            var matrixMock = new Mock<IMatrix>();

            //string[,] fakeMatrix = new string[Global.YMax, Global.XMax];
            //for (int i = 0; i < Global.YMax; i++)
            //{
            //    for (int j = 0; j < Global.XMax; j++)
            //    {
            //        fakeMatrix[i, j] = "1,1";
            //    }
            //}
            //matrixMock.SetupGet(m=>m.PathsMatrix).Returns(fakeMatrix);
            matrixMock.SetupGet(m=>m.Level).Returns(new Level());

            randMovement = new GhostHuntingRandomMovement(
                ghostMock.Object, matrixMock.Object, new PacMan());
        }

        [TestMethod]
        public void DecreaseSpeed_ShouldDecreaseSpeed()
        {
            //Arrange
            int speedBefore = randMovement.PixelMoved;
            int speedAfter;

            //Act
            randMovement.DecreaseSpeed();
            speedAfter = randMovement.PixelMoved;

            //Assert
            if(speedAfter >= speedBefore)
            {
                throw new System.Exception();
            }
        }

/*      [TestInitialize]
        public void TestInit()
        {

        }

        [TestMethod]
        [Ignore]
        [ExpectedException(typeof(System.Exception))]
        [Timeout(1000)]
        public void SomeTest()
        {
            // Arrange

            // Act

            //Assert
        }
*/
    }
}
