using StarWars.Interfaces;
using StarWars.InterfacesImpl;

namespace StarWars.Tests
{
    public class CannonLoaderTests
    {
        private readonly ICannonLoader _cannonLoader;
        
        public CannonLoaderTests()
        {
            _cannonLoader = new CannonLoader(); 
        }

        [Fact]
        public void Heights_isNull()
        {
            //Arrange
            IReadOnlyList<uint> heights = null;
            //Act
            var numberCannons = _cannonLoader.GetCannonCount(heights);
            //Assert
            Assert.True(numberCannons == 0);
        }

        [Fact]
        public void Heights_isEmpty()
        {
            //Arrange
            IReadOnlyList<uint> heights = new uint[] { };
            //Act
            var numberCannons = _cannonLoader.GetCannonCount(heights);
            //Assert
            Assert.True(numberCannons == 0); 
        }

        [Fact]
        public void Heights_isOne()
        {
            //Arrange
            IReadOnlyList<uint> heights = new uint[] { 3 };
            //Act
            var numberCannons = _cannonLoader.GetCannonCount(heights);
            //Assert
            Assert.True(numberCannons == 0);
        }

        [Fact]
        public void Heights_isPlateau()
        {
            //Arrange
            IReadOnlyList<uint> heights = new uint[] { 2,2,2,2 };
            //Act
            var numberCannons = _cannonLoader.GetCannonCount(heights);
            //Assert
            Assert.True(numberCannons == 0);
        }

        [Fact]
        public void isPeak()
        {
            //Arrange
            bool peak = false;
            CannonLoader can = new CannonLoader();
            //Act
            peak = can.isPeak(1, 4, 3);
            //Assert
            Assert.True(peak);
        }

        [Fact]
        public void isNotPeak()
        {
            //Arrange
            bool peak = false;
            CannonLoader can = new CannonLoader();
            //Act
            peak = can.isPeak(8, 10, 12);
            //Assert
            Assert.False(peak);
        }

        [Fact]
        public void ShortHeights()
        {
            //Arrange
            IReadOnlyList<uint> heights = new uint[] { 1, 6, 4, 5, 4, 5, 1, 2, 3, 4, 7, 2 };
            //Act
            var numberCannons = _cannonLoader.GetCannonCount(heights);
            //Assert
            Assert.Equal(3,numberCannons);
        }

        [Fact]
        public void LongHeigths()
        {
            //Arrange
            IReadOnlyList<uint> heights = new uint[] { 206, 11, 645, 601, 770, 755, 858, 637, 7, 540, 986, 935, 77, 968, 478, 18, 943, 352, 242, 454,
                514, 196, 592, 926, 164, 153, 149, 605, 458, 193, 22, 263, 309, 198, 921, 160, 699, 933, 207,
                337, 90, 552, 474, 490, 81, 788, 671, 76, 464, 340, 717, 394, 634, 795, 639, 10, 418, 719, 436,
                617, 605, 252, 179, 813, 517, 723, 625, 879, 46, 318, 319, 9, 145, 904, 363, 962, 721, 101, 845,
                376, 482, 73, 141, 117, 475, 627, 629, 513, 558, 911, 741, 980, 497, 590, 731, 837, 372, 660,
                973, 357, 162, 791, 29, 145, 21, 708, 249, 729, 432, 676, 288, 316, 873, 59, 135, 532, 111, 61,
                337, 889, 93, 112, 320, 135, 576, 339, 512, 554, 173, 525, 589, 61, 128, 487, 213, 690, 43, 995,
                96, 767, 378, 900, 81, 881, 623, 424, 106, 437, 455, 199, 726, 311, 322, 83, 264, 50, 471, 894,
                568, 682, 196, 695, 555, 906, 87, 226, 188, 385, 845, 444, 488, 115, 964, 570, 511, 193, 31,
                438, 511, 152, 232, 74, 99, 973, 798, 278, 738, 44, 223, 163, 219, 149, 426, 414, 571, 683, 344,
                174, 794, 396  };
            //Act
            var numberCannons = _cannonLoader.GetCannonCount(heights);
            //Assert
            Assert.Equal(14, numberCannons);
        }
    }
}