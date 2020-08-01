# Delegate (委托)



C# 中的委托（Delegate）类似于 C 或 C++ 中函数的指针。委托（Delegate） 是存有对某个方法的引用的一种引用类型变量。引用可在运行时被改变。

委托（Delegate）特别用于实现事件和回调方法。所有的委托（Delegate）都派生自 System.Delegate 类。


Runnoob的评论区里一个神奇的例子：

    委托多播实例：例如小明叫小张买完车票，之后接着又让他带张电影票：

    // 小张类
    public class MrZhang
        {
        // 其实买车票的悲情人物是小张
        public static void BuyTicket()
        {
                Console.WriteLine("NND,每次都让我去买票，鸡人呀！");
        }

        public static void BuyMovieTicket()
        {
            Console.WriteLine("我去，自己泡妞，还要让我带电影票！");
        }
    }

    //小明类
    class MrMing
    {
        // 声明一个委托，其实就是个“命令”
        public delegate void BugTicketEventHandler();

        public static void Main(string[] args)
        {
            // 这里就是具体阐述这个命令是干什么的，本例是MrZhang.BuyTicket“小张买车票”
            BugTicketEventHandler myDelegate = new BugTicketEventHandler(MrZhang.BuyTicket);

            myDelegate += MrZhang.BuyMovieTicket;
            // 这时候委托被附上了具体的方法
            myDelegate();
            Console.ReadKey();
        }
    }
