using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace FallingBall
{
    public enum STATE { FALL,GET,LOSE };        // 球的状态
    public class Ball
    {
        private const int width = 300;          // 背景区宽度
        private const int height = 500;         // 背景区高度
        private const int radius = 10;          // 小球半径
        private int boardWidth = 30;            // 板的宽度
        private const int boardHeight = 10;     // 板的高度
        private int ballX = 0;                  // 小球坐标
        private int ballY = 0;
        private int boardX = 0;                 // 板的坐标
        private int boardY;
        private int step;                       // 速度/步长
        public int BallX
        {
            set                                 // 控制小球在背景区以内，下同
            {
                if (value < 0)
                    ballX = 0;
                else if (value > width - 2 * radius)
                    ballX = width - 2 * radius;
                else ballX = value;
            }
            get { return ballX; }
        }
        public int BallY
        {
            set { ballY = value; }
            get { return ballY; }
        }
        public int BoardX
        {
            set
            {
                if (value < 0)
                    boardX = 0;
                else if (value > width - boardWidth)
                    boardX = width - boardWidth;
                else { boardX = value; }
            }
            get { return boardX; }
        }
        public int BoardY
        {
            set { boardY = value; }
            get { return boardY; }
        }
        
        // 只读属性
        public int Radius { get { return radius; } }
        public int BoardWidth { get { return boardWidth; } }
        public int BoardHeight { get { return boardHeight; } }
        public int Step { get { return step; } }

        private Random rand = new Random();     // 随机器

        public Ball()
        {
            boardY = height - boardHeight;
            step = 5;
        }

        public STATE CheckState()               // 检查状态
        {
            if (BallY + radius < height - boardHeight)
                return STATE.FALL;
            else
            {
                if (BallX >= BoardX && BallX + 2 * radius <= boardX + boardWidth)
                    return STATE.GET;
                else return STATE.LOSE;
            }
        }

        public void NewBall()                   // 随机化新球和板长
        {
            BallX = rand.Next(0, width - 2 * radius);
            BallY = 0;
            boardWidth = rand.Next(30, 70);
            BoardX = BoardX;
        }

        public Rectangle GetCanvas()            // 获得画布尺寸
        {
            return new Rectangle(0, 0, width, height);
        }

        public void StepFaster()                // 加速
        {
            step++;
        }
    }
}
