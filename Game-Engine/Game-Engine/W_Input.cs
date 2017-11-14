using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Game_Engine
{
    public partial class W_Input : Form
    {
        Input my_Input;
        public W_Input()
        {
            InitializeComponent();
            this.my_Input = new Input();
        }

        private void T_Update_Tick(object sender, EventArgs e)
        {
            this.my_Input.Update();
            L_X_Position.Text = my_Input.M_Position_X.ToString();
            L_Y_Position.Text = my_Input.M_Position_Y.ToString();
            if (this.my_Input.KB_Down_state == true) B_Down.BackColor = Color.Red;
            else B_Down.BackColor = Color.Black;
            if (this.my_Input.KB_Up_state == true) B_Up.BackColor = Color.Red;
            else B_Up.BackColor = Color.Black;
            if (this.my_Input.KB_Right_state == true) B_Right.BackColor = Color.Red;
            else B_Right.BackColor = Color.Black;
            if (this.my_Input.KB_Left_state == true) B_Left.BackColor = Color.Red;
            else B_Left.BackColor = Color.Black;
            if (this.my_Input.KB_Space_state == true) B_Space.BackColor = Color.Red;
            else B_Space.BackColor = Color.Black;
            if (this.my_Input.KB_Control_state == true) B_Control.BackColor = Color.Red;
            else B_Control.BackColor = Color.Black;
            if (this.my_Input.M_Left_state == true) B_M_Left.BackColor = Color.Red;
            else B_M_Left.BackColor = Color.Black;
            if (this.my_Input.M_Right_state == true) B_M_Right.BackColor = Color.Red;
            else B_M_Right.BackColor = Color.Black;
        }
    }
}
