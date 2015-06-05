using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassByValueVsReference
{
    class LearningArrays
    {
        //arrays have dimensionality. 1D is just a line of containers for values
        //2D is a grid of containers for values, 3D is a cube, and so on

        public int[,] ticTacToe = new int[3, 3]; //this creates a 3x3 grid, like a tictactoe board
        //the rows and columns are counted starting at 0 still. here are all the positions
        //in a 3x3 grid: 
        /*
        (0,0) (0,1) (0,2)
        (1,0) (1,1) (1,2)
        (2,0) (2,1) (2,2)
        */

            //sometimes it's ok to "waste" an element on null. the idea is that it's preferable 
            //for the program to fail spectacularly rather than complete but do the wrong thing
        string[] monthNames = new string[]
        {
            null, //element 0 doesn't correspond to any month
            "January", "February", "March", "April", "May", "June",
            "July", "August", "September", "October", "November", "December"
            //the element numbers 1-12 correspond to months 1-12
        };

       
        

    }
}
