using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FallingBall
{
    
    public partial class FormMain : Form
    {
        private int leftX = 50;     // 矩形框相对于窗口左上角的X偏移量
        private int leftY = 50;     // 矩形框相对于窗口左上角的Y偏移量
        private Ball gameBall = new Ball();
        private int life = 5;       // 生命值
        private int score = 0;      // 游戏分数
        
        public FormMain()
        {
            InitializeComponent();
            Width = 400;            // 窗体尺寸初始化
            Height = 650;
            gameBall.NewBall();     // 生成新球和新板
        }
        
        private void timMain_Tick(object sender, EventArgs e)
        {
            gameBall.BallY += gameBall.Step;                // 下落
            if (gameBall.CheckState() == STATE.GET)         // 接住
            {
                gameBall.NewBall();                         // 生成新球
                score += gameBall.Step * gameBall.Step;     // 按速度平方积分
                gameBall.StepFaster();                      // 加速
            }
            else if (gameBall.CheckState() == STATE.LOSE)   // 漏球
            {
                life--;                                     // 扣除生命值
                gameBall.NewBall();                         // 新球
            }
            lblLife.Text = string.Format("生命值：{0}", life);
            lblScore.Text = string.Format("分数：{0}", score);
            Invalidate();                                   // 刷新图像
            if (life == 0)                                  // 游戏结束
            {
                timMain.Enabled = false;                    // 停止计时器
                DialogResult tmpResult = MessageBox.Show(string.Format("游戏结束！您的最终分数是{0}分~", score));
                Close();                                    // 关闭窗口
            }
        }

        private void FormMain_Paint(object sender, PaintEventArgs e)
        {
            // 绘制背景、小球和板
            Graphics g = e.Graphics;
            Rectangle canvas = new Rectangle(leftX, leftY, gameBall.GetCanvas().Width,gameBall.GetCanvas().Height);
            g.FillRectangle(Brushes.Blue, canvas);
            Rectangle ball = new Rectangle(leftX + gameBall.BallX, leftY + gameBall.BallY, 2 * gameBall.Radius, 2 * gameBall.Radius);
            g.FillEllipse(Brushes.White, ball);
            Rectangle board = new Rectangle(leftX + gameBall.BoardX, leftY + gameBall.BoardY, gameBall.BoardWidth, gameBall.BoardHeight);
            g.FillRectangle(Brushes.Yellow, board);
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            // 由键盘控制板左右移动
            if (e.KeyCode == Keys.Left)
            {
                gameBall.BoardX -= 10;
            }
            else if (e.KeyCode == Keys.Right)
            {
                gameBall.BoardX += 10;
            }
        }
    }


}
