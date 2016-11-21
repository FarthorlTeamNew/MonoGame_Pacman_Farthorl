namespace Pacman.Tests.Handlers
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Interfaces;
    using Moq;

    [TestClass]
    public class GhostHuntingRandomMovementTest
    {
        global::Pacman.Handlers.GhostHuntingRandomMovement randMovement;

        [TestInitialize]
        public void Test()
        {
            var ghostMock = new Mock<Models.LevelObjects.Ghost>();
            var matrixMock = new Mock<IMatrix>();

            string[,] fakeMatrix = new string[Globals.Global.YMax, Globals.Global.XMax];
            for (int i = 0; i < Globals.Global.YMax; i++)
            {
                for (int j = 0; j < Globals.Global.XMax; j++)
                {
                    fakeMatrix[i, j] = "1,1";
                }
            }
            matrixMock.SetupGet(m=>m.PathsMatrix).Returns(fakeMatrix);

            randMovement = new global::Pacman.Handlers.GhostHuntingRandomMovement(
                ghostMock.Object, matrixMock.Object, new Models.PacMan());
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
