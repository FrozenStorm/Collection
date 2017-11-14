using System;

namespace Game_Engine
{
    class Knoten
    {
        int now_x;
        public int Now_x
        {
            set
            {
                now_x = value;
            }
            get
            {
                return now_x;
            }
        }
        int now_y;
        public int Now_y
        {
            set
            {
                now_y = value;
            }
            get
            {
                return now_y;
            }
        }
        int from_z;
        public int From_z
        {
            set
            {
                from_z = value;
            }
            get
            {
                return from_z;
            }
        }
        public Knoten(int from_z,int now_x,int now_y)
        {
            this.now_x = now_x;
            this.now_y = now_y;
            this.from_z = from_z;
        }
    }
}
